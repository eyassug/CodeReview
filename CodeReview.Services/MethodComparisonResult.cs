﻿using System;
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
            if(baseMethod == null)
                throw new ArgumentNullException("baseMethod");
            if(refactoredMethod == null)
                throw new ArgumentNullException("refactoredMethod");
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
            return _refactoredMethod.Body.Lines.Where(m => !_baseMethod.Body.Lines.Contains(m)).ToList();
        }

        public bool HaveIdenticalParameters()
        {
            if(_baseMethod.Parameters.Count != _refactoredMethod.Parameters.Count)
                return false;
            return true;
        }

        public bool AreIdentical()
        {
            return (HaveIdenticalParameters() && _baseMethod.ReturnType == _refactoredMethod.ReturnType);
        }
        #endregion

        #region Properties
        


        #endregion

    }
}
