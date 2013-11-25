using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roslyn.Compilers.CSharp;

namespace CodeReview.Services
{
    public class CodeFile
    {
        private readonly SyntaxTree _syntaxTree;
        private ICollection<CSharpClass> _classes;

        public CodeFile(SyntaxTree syntaxTree)
        {
            _syntaxTree = syntaxTree;
        }

        #region Properties

        public string FileName { get { return _syntaxTree.FilePath.Split('\\').Last(); } }
        public ICollection<CSharpClass> Classes
        {
            get
            {
                return _classes ??
                       (_classes = GetClasses(_syntaxTree.GetRoot().Members));
            }
        }

        public string Language { get { return _syntaxTree.GetRoot().Language; } }
        #endregion

        #region Static Helpers
        private static ICollection<CSharpClass> GetClasses(IEnumerable<MemberDeclarationSyntax> memberDeclarations)
        {
            ICollection<ClassDeclarationSyntax> classDeclarations = new List<ClassDeclarationSyntax>();
            var memberDeclarationSyntax = memberDeclarations as List<MemberDeclarationSyntax> ?? memberDeclarations.ToList();
            if (memberDeclarationSyntax.OfType<NamespaceDeclarationSyntax>().Any())
                classDeclarations = memberDeclarationSyntax.OfType<NamespaceDeclarationSyntax>().First().Members.OfType<ClassDeclarationSyntax>().ToList();
            if (classDeclarations != null)
                return classDeclarations.Select(classDeclarationSyntax => new CSharpClass(classDeclarationSyntax)).ToList();
            return new List<CSharpClass>();
        }

        #endregion
    }
}
