using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Services.Comparison
{
    public class MethodNotChanged : MethodNotRefacored
    {
        public MethodNotChanged() : base("Method Not Changed!")
        {
            
        }
    }
}
