using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public IList<string> Lines { get { return _blockSyntax.Statements.Select(m => m.ToString().Trim('\n')).ToList(); } }

        public IList<string> Queries { get { return GetQueries(); } }

        IList<string> GetQueries()
        {
            string queryPattern = @"SELECT\s.*FROM\s.*";
            var  regExpression = new Regex ( queryPattern,RegexOptions.IgnoreCase | RegexOptions.Multiline );
            var queryLines = (from line in Lines let match = regExpression.Match(line.Trim().Replace('\n',' ')) where match.Success select line).ToList();
            
            if(queryLines.Count==0)
            {
                queryPattern = @"UPDATE\s.*SET\s.*";
                regExpression = new Regex(queryPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                queryLines = (from line in Lines let match = regExpression.Match(line.Trim().Replace('\n', ' ')) where match.Success select line).ToList();
            }

            if (queryLines.Count == 0)
            {
                queryPattern = @"DELETE\s.*FROM\s.*";
                regExpression = new Regex(queryPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                queryLines = (from line in Lines let match = regExpression.Match(line.Trim().Replace('\n', ' ')) where match.Success select line).ToList();
            }

            var queries = queryLines.Select(queryLine => queryLine.Split('\"').ToList()).Select(buildingBlocks => buildingBlocks[1].Trim()).ToList();
            return queries.ToList();
        }
    }
}
