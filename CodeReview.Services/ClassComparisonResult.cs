using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeReview.Services
{
    public class ClassComparisonResult
    {
        private readonly CSharpClass _baseClass;
        private readonly CSharpClass _refactoredClass;
        private ICollection<MethodComparisonResult> _methodComparisonResults = new List<MethodComparisonResult>();

        public ClassComparisonResult(CSharpClass baseClass, CSharpClass refactoredClass)
        {
            if (baseClass == null)
                throw new ArgumentNullException("baseClass");
            if (refactoredClass == null)
                throw new ArgumentNullException("refactoredClass");
            _baseClass = baseClass;
            _refactoredClass = refactoredClass;
            CompareMethods();
        }

        #region Methods
        public bool HaveIdenticalMethods()
        {
            return (_baseClass.Methods.Count == _refactoredClass.Methods.Count);

        }

        public bool HaveIdenticalVariables()
        {
            return true;
        }

        void CompareMethods()
        {

            foreach (var method in _baseClass.Methods.Where(m => _refactoredClass.Methods.Select(r => r.Name).Contains(m.Name)))
            {
                Method copyMethod = null;
                var overloads = _refactoredClass.Methods.Where(m => m.Name == method.Name).ToList();
                var originalParameterSet = method.Parameters.Aggregate("", (current, parameter) => current + parameter.Type);
                foreach (var overload in overloads)
                {
                    string typeString = overload.Parameters.Aggregate("", (current, parameter) => current + parameter.Type.ToString());
                    if (typeString == originalParameterSet)
                        copyMethod = overload;
                }
                if (copyMethod == null)
                {
                    throw new Exception();
                }
                _methodComparisonResults.Add(new MethodComparisonResult(method, copyMethod));
            }
        }
        #endregion

        #region Properties

        public ICollection<MethodComparisonResult> MethodComparisonResults
        {
            get
            {
                return _methodComparisonResults;
            }
        }


        #endregion
    }
}
