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
        public MethodComparisonResultBase Compare(Method baseMethod, Method queryMethod)
        {
            var baseMethodQueryString = GetQueryString(baseMethod.Body);
            var queryMethodQueryString = GetQueryString(queryMethod.Body);
            if (baseMethodQueryString != null && queryMethodQueryString != null)
            {
                if (baseMethodQueryString.Trim() == queryMethodQueryString.Trim())
                    return new MethodRefactorSuccess();
            }

            return new MethodRefactorError();
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
            return baseMethod.Body.Lines.Where(m => !refactoredMethod.Body.Lines.Contains(m)).ToList();
        }

        public IList<string> GetAddedLines(Method baseMethod, Method refactoredMethod)
        {
            return refactoredMethod.Body.Lines.Where(m => !baseMethod.Body.Lines.Contains(m)).ToList();
        }

        #region Private Helper Methods

        static string GetQueryString(MethodBody methodBody)
        {
            return methodBody.Queries.FirstOrDefault();
        }
        #endregion
    }
}
