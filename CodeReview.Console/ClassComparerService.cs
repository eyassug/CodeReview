using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeReview.Services;
using CodeReview.Services.Comparison;

namespace CodeReview.Console
{
    class ClassComparerService : IClassComparerService
    {
        private readonly IMethodComparerService _methodComparer;
        private ICodeFileService _codeFileService;

        public ClassComparerService()
        {
            _methodComparer = new MethodComparerService();
            _codeFileService = new CodeFileService();
        }

        public ClassComparisonResult Compare(CSharpClass baseClass, CSharpClass refactoredClass, string refactoredQueryDirectoryPath)
        {
            var comparisonResult = new ClassComparisonResult(baseClass,refactoredClass);
            
            foreach (var baseMethod in baseClass.Methods)
            {
                var matchingMethod = _methodComparer.FindMatchingOverload(baseMethod, refactoredClass.Methods);
                if (matchingMethod!=null)
                {
                    var addedLines = _methodComparer.GetAddedLines(baseMethod, matchingMethod);
                    var removedLines = _methodComparer.GetRemovedLines(baseMethod, matchingMethod);
                    if(addedLines.Any(m => m.Contains("HCMIS.Repository.Queries")))
                    {
                        // Works for only one query per method. 
                        var queryMethodCallLine = addedLines.First(m => m.Contains("HCMIS.Repository.Queries"));
                        var queryClass = GetQueryClass(queryMethodCallLine, refactoredQueryDirectoryPath);
                        var queryMethod = GetQueryMethod(queryClass, queryMethodCallLine);
                        var result = _methodComparer.Compare(baseMethod, queryMethod);
                        comparisonResult.MethodComparisonResults.Add(result);
                    }
                    else
                    {
                        if(addedLines.Count == 0 && removedLines.Count == 0)
                        {
                            comparisonResult.MethodComparisonResults.Add(new MethodNotChanged());
                        }
                        else
                        {
                            comparisonResult.MethodComparisonResults.Add(new MethodNotRefacored());
                        }

                    }
                    
                }
                else
                {
                    comparisonResult.MethodComparisonResults.Add(
                        new OtherError("Matching method not found in Refactored class"));
                }
                
            }

            return comparisonResult;
        }

        #region Private Helper Methods

        static Method GetQueryMethod(CSharpClass queryClass, string queryMethodCallLine)
        {
            var queryLineShortened = queryMethodCallLine.Remove(0, queryMethodCallLine.IndexOf("HCMIS.Repository.Queries"));
            var queryWithoutParam = queryLineShortened.Trim().Split('(')[0];
            var method = queryClass.Methods.First(m => m.Name == queryWithoutParam.Split('.')[queryWithoutParam.Split('.').Length - 1]);
            return method;
        }

        static CSharpClass GetQueryClass(string queryMethodCallLine, string refactoredQueryDirectoryPath)
        {
            var queryLineShortened = queryMethodCallLine.Remove(0, queryMethodCallLine.IndexOf("HCMIS.Repository.Queries"));
            var queryWithoutParam = queryLineShortened.Trim().Split('(')[0];
            
            var className = queryWithoutParam.Split('.')[queryWithoutParam.Split('.').Length - 2];
            var queryFilePath = Path.Combine(refactoredQueryDirectoryPath, className + ".cs");
            var queryCodeFile = new CodeFileService();
            var queryClass = queryCodeFile.Create(queryFilePath).Classes.First();
            return queryClass;
        }

        #endregion


    }
}
