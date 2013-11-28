using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeReview.Services;
using CodeReview.Services.Comparison;

namespace CodeReview.Console
{
    class MethodComparerService : IMethodComparerService
    {
        public MethodComparisonResultBase Compare(Method baseMethod, Method refactoredMethod)
        {
            throw new NotImplementedException();
        }

        public Method FindMatchingOverload(Method method, IList<Method> methodCollection)
        {
            var originalParameterSet = method.Parameters.Aggregate("", (current, parameter) => current + parameter.Type);
            foreach (var methodOverload in methodCollection)
            {
                var overloadParameterSet = methodOverload.Parameters.Aggregate("", (current, parameter) => current + parameter.Type.ToString());
                if (overloadParameterSet == originalParameterSet)
                    return methodOverload;
            }
            return null;
        }

        public IList<string> GetRemovedLines(Method baseMethod, Method refactoredMethod)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetAddedLines(Method baseMethod, Method refactoredMethod)
        {
            throw new NotImplementedException();
        }
    }
}
