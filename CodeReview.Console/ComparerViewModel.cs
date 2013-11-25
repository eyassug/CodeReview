using System;
using System.Collections.Generic;
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
            var result = _classComparerService.Compare(class1,class2);
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

    }
}
