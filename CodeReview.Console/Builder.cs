using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;


namespace ClassParser
{
    public class Builder
    {
        public IEnumerable<string> ParseFile(string filePathLegacy, string filePathNew)
        {
            SyntaxTree syntaxTreeLegacy = SyntaxTree.ParseFile(filePathLegacy);
            SyntaxTree syntaxTreeNew = SyntaxTree.ParseFile(filePathNew);

            var methodsLegacy = syntaxTreeLegacy.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();
            var methodsNew = syntaxTreeNew.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();

            var legacyCount = methodsLegacy.Count();
            var newCount = methodsNew.Count();

            Compilation compilation = Compilation.Create("New");

            //SemanticModel model = compilation.GetSemanticModel(syntaxTreeLegacy);

            var countComparison = string.Format("Method Count (Legacy code:{0}, New code:{1} \n", legacyCount, newCount);

            yield return countComparison;

            foreach (var method in methodsLegacy)
            {
                var declaration = (MethodDeclarationSyntax) method;
                var methodName = declaration.Identifier.ToString();

                if (methodsNew.
                        Count(syntax => (syntax).Identifier.ToString().Equals(methodName)) == 0)
                {
                    var methodNameComparison = string.Format("In Legacy Code: {0}, Not found in New Code \n",
                                                             method.GetText());
                    yield return methodNameComparison;
                }
                
            }
        }
    }
}