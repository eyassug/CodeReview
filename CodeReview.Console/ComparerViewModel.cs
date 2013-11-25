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
        }


        #endregion

        #region Commands

        #endregion

        #region Methods
        public void Compare()
        {
            _baseCodeFile = _codeFileService.Create(File1);
            _refactoredCodeFile = _codeFileService.Create(File2);
            var result = _classComparerService.Compare(_baseCodeFile.Classes.First(),
                                                       _refactoredCodeFile.Classes.First());

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
