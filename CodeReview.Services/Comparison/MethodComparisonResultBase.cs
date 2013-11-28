using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Services.Comparison
{
    public abstract class MethodComparisonResultBase
    {
        private readonly Method _baseMethod;

        protected MethodComparisonResultBase()
        {
            
        }

        protected MethodComparisonResultBase(string result)
        {
            Result = result;
        }

        protected MethodComparisonResultBase(Method baseMethod, string result) :this(result)
        {
            _baseMethod = baseMethod;
        }

        #region Methods
        public Method BaseMethod
        {
            get { return _baseMethod; }
        }

        #endregion

        public string Result { get; set; }
    }
}
