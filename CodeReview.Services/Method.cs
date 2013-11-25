using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roslyn.Compilers.CSharp;

namespace CodeReview.Services
{
    public class Method
    {
        private readonly MethodDeclarationSyntax _methodDeclarationSyntax;
        private MethodBody _methodBody;

        public Method(MethodDeclarationSyntax methodDeclarationSyntax)
        {
            if(methodDeclarationSyntax == null)
                throw new ArgumentNullException("methodDeclarationSyntax");
            _methodDeclarationSyntax = methodDeclarationSyntax;
        }

        #region Properties

        public string AccessModifer { get { return ""; } }
        public string Name { get { return _methodDeclarationSyntax.Identifier.ToString(); } }
        public ICollection<ParameterSyntax> Parameters { get { return _methodDeclarationSyntax.ParameterList.Parameters.ToList(); } }
        public MethodBody Body { get { return _methodBody ?? (_methodBody = new MethodBody(_methodDeclarationSyntax.Body)); } }
        public string ReturnType
        {
            get
            {
                return _methodDeclarationSyntax.ReturnType.ToString();
            }
        }

        #endregion
    }
}
