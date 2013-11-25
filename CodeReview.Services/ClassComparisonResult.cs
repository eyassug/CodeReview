using System;

namespace CodeReview.Services
{
    public class ClassComparisonResult
    {
        private readonly CSharpClass _baseClass;
        private readonly CSharpClass _refactoredClass;

        public ClassComparisonResult(CSharpClass baseClass, CSharpClass refactoredClass)
        {
            if(baseClass == null)
                throw new ArgumentNullException("baseClass");
            if(refactoredClass == null)
                throw new ArgumentNullException("refactoredClass");
            _baseClass = baseClass;
            _refactoredClass = refactoredClass;
        }

        #region Methods
        public bool HaveIdenticalMethods()
        {
            return (_baseClass.Methods.Count == _refactoredClass.Methods.Count);

        }

        public bool HaveIdenticalVariables()
        {
            
        }

        #endregion
    }
}
