using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeReview.Services
{
    public class MethodComparisonResult
    {
        private readonly Method _baseMethod;
        private readonly Method _refactoredMethod;

        public MethodComparisonResult(Method baseMethod, Method refactoredMethod)
        {
            _baseMethod = baseMethod;
            _refactoredMethod = refactoredMethod;
        }

        #region Methods
        public ICollection<string> GetRemovedLines()
        {
            return _baseMethod.Body.Lines.Where(m => !_refactoredMethod.Body.Lines.Contains(m)).ToList();
        }

        public ICollection<string> GetAddedLines()
        {

        }

        public bool HaveSimilarParameters()
        {
            if()
            return true;
        }

        #endregion

        #region Properties



        #endregion

    }
}
