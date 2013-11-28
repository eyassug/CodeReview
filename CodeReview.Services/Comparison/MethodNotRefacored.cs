using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Services.Comparison
{
    public class MethodNotRefacored : MethodComparisonResultBase
    {
        public MethodNotRefacored()
            : base("Method Not Changed!")
        {
            
        }

        public MethodNotRefacored(string result)
            : base(result)
        {
            
        }
    }
}
