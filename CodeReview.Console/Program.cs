using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;

namespace CodeReview.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var viewModel = new ComparerViewModel();
            viewModel.File1 = @"C:\Users\Eyassu\Documents\CodeReviewTest\Comparison\BLL Legacy\Models\ItemUnit.cs";
            viewModel.File2 = @"C:\Users\Eyassu\Documents\CodeReviewTest\Comparison\New\BLL\Models\ItemUnit.cs";
            viewModel.QueriesDirectory =
                @"C:\Users\Eyassu\Documents\CodeReviewTest\Comparison\New\Repository\HCMIS.Repository\Queries";
            
            var result = viewModel.Compare();
            if (result.HaveIdenticalMethods())
                System.Console.WriteLine("Have Identical Methods");
            if(result.HaveIdenticalVariables())
                System.Console.WriteLine("Have Identical variables");
            System.Console.ReadLine();
        }
    }
}
