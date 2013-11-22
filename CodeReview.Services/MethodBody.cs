using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roslyn.Compilers.CSharp;

namespace CodeReview.Services
{
    public class MethodBody
    {
        private readonly BlockSyntax _blockSyntax;

        public MethodBody(BlockSyntax blockSyntax)
        {
            _blockSyntax = blockSyntax;
        }

        public ICollection<string> Lines { get { return _blockSyntax.Statements.Select(m => m.ToString()).ToList(); } }
    }
}
