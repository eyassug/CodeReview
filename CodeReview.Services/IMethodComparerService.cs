using System;

namespace CodeReview.Services
{
    public interface IMethodComparerService
    {
        MethodComparisonResult Compare(Method method1, Method method2);
    }
}
