using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roslyn.Compilers.CSharp;


namespace CodeReview.Services
{
    public class CSharpClass
    {
        private readonly ClassDeclarationSyntax _classDeclarationSyntax;
        private ICollection<Method> _methods; 

        #region Constructors
        public CSharpClass(ClassDeclarationSyntax classDeclarationSyntax)
        {
            if(classDeclarationSyntax == null)
                throw new ArgumentNullException("classDeclarationSyntax");
            _classDeclarationSyntax = classDeclarationSyntax;
        }

        #endregion


        #region Properties

        public string Name { get { return _classDeclarationSyntax.Identifier.ToString(); } }
        public string FullName { get { return _classDeclarationSyntax.Identifier.ToFullString(); } }

        public string Namespace
        {
            get
            {
                var dotClassName = string.Format(".{0}", Name);
                return FullName.Replace(dotClassName, "");
            }
        }

        public ICollection<ConstructorDeclarationSyntax> Constructors
        {
            get { return _classDeclarationSyntax.Members.OfType<ConstructorDeclarationSyntax>().ToList(); }
        } 

        public ICollection<Method> Methods
        {
            get { return _methods ?? (_methods = GetMethods(_classDeclarationSyntax.Members.OfType<MethodDeclarationSyntax>().ToList())); }
        }


        #endregion

        #region Private Helper Methods
        public static ICollection<Method> GetMethods(ICollection<MethodDeclarationSyntax> methodDeclarations)
        {
            return methodDeclarations.Select(methodDeclaration => new Method(methodDeclaration)).ToList();
        }
        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}
