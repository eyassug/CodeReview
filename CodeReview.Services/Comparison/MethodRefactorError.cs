using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Services.Comparison
{
    public class MethodRefactorError : MethodComparisonResultBase
    {
        public MethodRefactorError()
            : base("Refactor error")
        {
            
        }

        public MethodRefactorError(Method baseMethod, Method queryMethod)
        {
            QueryMethod = queryMethod;
            BaseMethod = baseMethod;
        }
        public Method QueryMethod { get; private set; }
    }
}
