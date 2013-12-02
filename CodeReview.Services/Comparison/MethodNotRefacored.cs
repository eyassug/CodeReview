using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Services.Comparison
{
    public class MethodNotRefacored : MethodComparisonResultBase
    {
        public MethodNotRefacored(Method baseMethod)
            : base(baseMethod, "Method Not Changed!")
        {
            
        }

        public MethodNotRefacored(Method baseMethod, string result)
            : base(baseMethod, result)
        {
            
        }
    }
}
