using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Services.Comparison
{
    public class OtherError : MethodComparisonResultBase
    {
        public OtherError(Method baseMethod, string result) : base(baseMethod, result)
        {
            
        }
    }
}
