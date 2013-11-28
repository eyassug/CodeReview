using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Services.Comparison
{
    public abstract class MethodComparisonResultBase
    {
        
        protected MethodComparisonResultBase()
        {
            
        }

        protected MethodComparisonResultBase(string result)
        {
            Result = result;
        }

        protected MethodComparisonResultBase(Method baseMethod, string result) :this(result)
        {
            BaseMethod = baseMethod;
        }

        #region Methods

        public Method BaseMethod { get; protected set; }

        #endregion

        public string Result { get; set; }
    }
}
