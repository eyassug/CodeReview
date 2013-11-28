using System;
using System.Collections.Generic;
using System.Linq;
using CodeReview.Services.Comparison;

namespace CodeReview.Services
{
    public class ClassComparisonResult
    {
        private readonly CSharpClass _baseClass;
        private readonly CSharpClass _refactoredClass;
        private readonly ICollection<MethodComparisonResultBase> _methodComparisonResults = new List<MethodComparisonResultBase>();

        public ClassComparisonResult(CSharpClass baseClass, CSharpClass refactoredClass)
        {
            if (baseClass == null)
                throw new ArgumentNullException("baseClass");
            if (refactoredClass == null)
                throw new ArgumentNullException("refactoredClass");
            _baseClass = baseClass;
            _refactoredClass = refactoredClass;
        }

        #region Properties

        public ICollection<MethodComparisonResultBase> MethodComparisonResults
        {
            get
            {
                return _methodComparisonResults;
            }
            
        }


        #endregion
    }
}
