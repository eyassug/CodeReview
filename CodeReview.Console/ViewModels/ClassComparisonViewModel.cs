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
        private ClassComparisonResult _comparisonResult;

        public ClassComparisonViewModel()
        {
            _classComparer = new ClassComparerService();
        }

        public ClassComparisonViewModel(CSharpClass baseClass,CSharpClass refactoredClass)
            : this()
        {
            _baseClass = baseClass;
            _refactoredClass = refactoredClass;
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
            _comparisonResult= _classComparer.Compare(_baseClass, _refactoredClass);
        }

        public ClassComparisonResult ComparisonResult
        {
            get { return _comparisonResult; }
        }
    }
}
