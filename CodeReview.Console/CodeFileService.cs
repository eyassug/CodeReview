using System;
using System.Collections.Generic;
using System.IO;
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
            if(!File.Exists(filePath))
                throw new FileNotFoundException(string.Format("The file '{0}' was not found!",filePath));
            return new CodeFile(SyntaxTree.ParseFile(filePath));
        }
    }
}
