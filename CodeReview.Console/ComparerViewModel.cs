using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeReview.Services;

namespace CodeReview.Console
{
    class ComparerViewModel
    {
        #region Fields

        private readonly ICodeFileService _codeFileService;
        private IClassComparerService _classComparerService;
        private string _sourceFilePath;
        private string _refactoredFilePath;
        private CodeFile _baseCodeFile;
        private CodeFile _refactoredCodeFile;
        private CodeFile _queryCodeFile;
        #endregion


        #region Constructors
        
        public ComparerViewModel()
        {
            _codeFileService = new CodeFileService();
            _classComparerService = new ClassComparerService();
        }


        #endregion

        #region Commands

        #endregion

        #region Methods
        public ClassComparisonResult Compare()
        {
            _baseCodeFile = _codeFileService.Create(File1);
            _refactoredCodeFile = _codeFileService.Create(File2);
            var class1 = _baseCodeFile.Classes.First();
            var class2 = _refactoredCodeFile.Classes.First();
            var method1 = class1.Methods.First();
            var method2 = class2.Methods.First(m => m.Name == method1.Name);
            
            // Get query from method1
            
            // Get added lines from method1 (methodComparisonResult)
            // Browse to code in added line

            var queries = method1.Body.Queries.First();
            var queries2 = method2.Body.Queries;
            

            var result = _classComparerService.Compare(class1,class2);
            foreach (var methodComparisonResult in result.MethodComparisonResults)
            {
                var removedLines = methodComparisonResult.GetRemovedLines();
                var addedLines = methodComparisonResult.GetAddedLines();
                var queryLine = addedLines.First(m => m.Contains("HCMIS.Repository.Queries"));
                
                var className = queryLine.Split('.')[queryLine.Split('.').Length - 2];
                var queryFilePath = Path.Combine(QueriesDirectory, className+".cs");
                _queryCodeFile = _codeFileService.Create(queryFilePath);
                var queryClass = _queryCodeFile.Classes.First();
                var method = queryClass.Methods.First(m => m.Name == queryLine.Split('.')[queryLine.Split('.').Length - 1].Split('(')[0]);
                var refactoredQuery = method.Body.Queries.First();
                if(refactoredQuery.Equals(queries))
                {
                    var comparisonResult = "Are equal";
                }
            }
            return result;

        }

        public bool CanCompare()
        {
            return true;
        }

        #endregion

        #region Properties

        public string File1
        {
            get { return _sourceFilePath; }
            set
            {
                if(_sourceFilePath == value)
                    return;
                _sourceFilePath = value;
            }
        }

        public string File2
        {
            get { return _refactoredFilePath; }
            set
            {
                if (_refactoredFilePath == value)
                    return;
                _refactoredFilePath = value;
            }
        }




        #endregion


        public string QueriesDirectory { get; set; }
    }
}
