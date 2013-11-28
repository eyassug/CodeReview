using System;
using System.Collections.Generic;
using CodeReview.Services.Comparison;

namespace CodeReview.Services
{
    public interface IMethodComparerService
    {
        MethodComparisonResultBase Compare(Method baseMethod, Method refactoredMethod);
        Method FindMatchingOverload(Method method, IList<Method> methodCollection);
        IList<string> GetRemovedLines(Method baseMethod, Method refactoredMethod);
        IList<string> GetAddedLines(Method baseMethod, Method refactoredMethod);
    }
}
