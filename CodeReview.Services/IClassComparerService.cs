using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Services
{
    public interface IClassComparerService
    {
        ClassComparisonResult Compare(CSharpClass baseClass, CSharpClass refactoredClass);
    }
}
