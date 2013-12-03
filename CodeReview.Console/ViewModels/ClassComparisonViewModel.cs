using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeReview.Services;

namespace CodeReview.Console.ViewModels
{
    public class ClassComparisonViewModel
    {
        private IClassComparerService _classComparer;
        private CSharpClass _baseClass;
        private CSharpClass _refactoredClass;
        private CSharpClass _queryClass;
        private ClassComparisonResult _comparisonResult;
        private string _queriesDirectory;

        public ClassComparisonViewModel()
        {
            _classComparer = new ClassComparerService();
        }

        public ClassComparisonViewModel(CSharpClass baseClass,CSharpClass refactoredClass,string queriesDirectory) : this()
        {
            _baseClass = baseClass;
            _refactoredClass = refactoredClass;
            _queriesDirectory = queriesDirectory;
        }

        public List<MethodComparisonViewModel> MethodComparisons { get; set; }

        public CSharpClass BaseClass
        {
            get { return _baseClass; }
            set { _baseClass = value; }
        }

        public CSharpClass RefactoredClass
        {
            get { return _refactoredClass; }
            set
            {
                if(_refactoredClass == value)
                    return;
                _refactoredClass = value;
            }
        }

        public void Compare()
        {
            _comparisonResult = _classComparer.Compare(_baseClass, _refactoredClass, _queriesDirectory);
        }

        public ClassComparisonResult ComparisonResult
        {
            get { return _comparisonResult; }
        }
    }
}
