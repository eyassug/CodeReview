using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roslyn.Compilers.CSharp;

namespace CodeReview.Services
{
    class MethodParameter
    {
        private readonly ParameterSyntax _parameter;

        public MethodParameter(ParameterSyntax parameter)
        {
            _parameter = parameter;
        }

        public string Name { get { return _parameter.Identifier.ToString(); } }
        public string Type { get { return _parameter.Type.ToString(); } }
    }
}
