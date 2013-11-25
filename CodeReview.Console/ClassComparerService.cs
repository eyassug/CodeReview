using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeReview.Services;

namespace CodeReview.Console
{
    class ClassComparerService : IClassComparerService
    {
        public ClassComparisonResult Compare(CSharpClass baseClass, CSharpClass refactoredClass)
        {
            return new ClassComparisonResult(baseClass,refactoredClass);
        }
    }
}
