using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Services.Comparison
{
    public class MethodRefactorError : MethodComparisonResultBase
    {
        public string ErrorDescription { get; set; }

        public Method RefactoredMethod { get; set; }
        public Method QueryMethod { get; set; }
    }
}
