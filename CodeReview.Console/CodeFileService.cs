using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeReview.Services;
using Roslyn.Compilers.CSharp;

namespace CodeReview.Console
{
    class CodeFileService : ICodeFileService
    {
        public CodeFile Create(string filePath)
        {
            return new CodeFile(SyntaxTree.ParseFile(filePath));
        }
    }
}
