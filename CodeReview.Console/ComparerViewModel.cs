using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeReview.Console.ViewModels;
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
            //_baseCodeFile = _codeFileService.Create(File1);
            //_refactoredCodeFile = _codeFileService.Create(File2);

            //if (_baseCodeFile.Classes.Count == 0)
            //    return null;

            //var class1 = _baseCodeFile.Classes.First();
            //var class2 = _refactoredCodeFile.Classes.First();
            //var result = _classComparerService.Compare(class1, class2);
            
            //foreach (var methodComparisonResult in result.MethodComparisonResults)
            //{
            //    if (methodComparisonResult.BaseMethod.Body.Queries.Count == 0)
            //        continue; //For now let's just pass this, we will need to show it later though.
                
            //    var removedLines = methodComparisonResult.GetRemovedLines();
            //    var addedLines = methodComparisonResult.GetAddedLines();
            //    string outputResult = "";
            //    if (addedLines.Count == 0)
            //    {
            //        outputResult = string.Format("SAME: {0} \n", methodComparisonResult.BaseMethod.Name);
            //    }
            //    else
            //    {
            //        try
            //        {
            //            var queryLine = addedLines.FirstOrDefault(m => m.Contains("HCMIS.Repository.Queries"));
            //            if(queryLine == null)
            //            {
            //                throw new Exception();
            //                outputResult = string.Format("{2}: Class {0} Method {1} \n", _baseCodeFile.Classes.First().Name, methodComparisonResult.BaseMethod.Name, "ERROR - Not Refactored");
            //            }
            //            var queryLineShortened = queryLine.Remove(0, queryLine.IndexOf("HCMIS.Repository.Queries"));
            //            var queryWithoutParam = queryLineShortened.Trim().Split('(')[0];
            //            //LoadFromRawSQL and the query on the same line.

            //            var className = queryWithoutParam.Split('.')[queryWithoutParam.Split('.').Length - 2];
            //            var queryFilePath = Path.Combine(QueriesDirectory, className + ".cs");
            //            _queryCodeFile = _codeFileService.Create(queryFilePath);
            //            var queryClass = _queryCodeFile.Classes.First();
            //            var method =
            //                queryClass.Methods.First(
            //                    m => m.Name == queryWithoutParam.Split('.')[queryWithoutParam.Split('.').Length - 1]);
            //            var refactoredQuery = method.Body.Queries.First();


            //            string successResult =
            //                refactoredQuery.Equals(methodComparisonResult.BaseMethod.Body.Queries.First()) ? "SUCCESS" : "ERROR";

            //            outputResult = string.Format("{2}: Class {0} Method {1} \n", className, method, successResult);
            //        }
            //        catch (Exception)
            //        {

            //            outputResult = string.Format("{2}: Class {0} Method {1} \n", _baseCodeFile.Classes.First().Name, methodComparisonResult.BaseMethod.Name, "ERROR - Not Refactored");
            //        }
                    
            //    }

            //    var stream = _outputFile.AppendText();
            //    stream.Write(outputResult);
            //    stream.Close();

            //}

            return null;
        }

        public void CompareDirectories()
        {
            _outputFile = new FileInfo(Path.Combine(OutputDirectory.FullName, "ComparisonResult.txt"));
            

            foreach (var csFile in DirectoryOriginal.CSharpFiles)
            {
                File1 = csFile.FullName;
                //The following is dirty hack.  Should be better.  Basically we're manually mapping the files between the two BLLs
                File2 = File1.Replace("BLL Legacy", @"New\BLL");
                var baseClass = new CodeFileService();
                var refactoredClass = new CodeFileService();

                var baseCodeFile = baseClass.Create(File1);
                var refactoredCodeFile = refactoredClass.Create(File2);
                
                if(baseCodeFile.Classes.Count == 0 || refactoredCodeFile.Classes.Count  == 0)
                {
                    continue;
                }

                var classComparisonViewModel = new ClassComparisonViewModel(
                    baseCodeFile.Classes.First(), refactoredCodeFile.Classes.First(),
                    QueriesDirectory);
                classComparisonViewModel.Compare();

                var methodComparisonResults = classComparisonViewModel.ComparisonResult.MethodComparisonResults;

                foreach (var methodComparisonResultBase in methodComparisonResults)
                {
                    var stream = _outputFile.AppendText();
                    var message = string.Format("{0} Result: {1} \n", methodComparisonResultBase.BaseMethod.Name,
                                                methodComparisonResultBase.Result); 
                    stream.Write(message);
                    stream.Close();
                }
            }
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

        public string RefactorDirectory { get; set; }

        public CodeDirectory DirectoryOriginal { get; set; }

        public DirectoryInfo OutputDirectory { get; set; }

        private FileInfo _outputFile;

    }
}
