using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Services.Comparison
{
    public class MethodRefactorSuccess : MethodComparisonResultBase
    {
        public MethodRefactorSuccess(Method baseMethod)
            : base(baseMethod, "Successful!")
        {
            
        }
    }
}
