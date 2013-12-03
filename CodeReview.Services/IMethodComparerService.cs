﻿using System;
using System.Collections.Generic;
using CodeReview.Services.Comparison;

namespace CodeReview.Services
{
    public interface IMethodComparerService
    {
        MethodComparisonResultBase Compare(Method baseMethod, Method queryMethod);
        Method FindMatchingOverload(Method method, IEnumerable<Method> methodCollection);
        IList<string> GetRemovedLines(Method baseMethod, Method refactoredMethod);
        IList<string> GetAddedLines(Method baseMethod, Method refactoredMethod);
    }
}
