using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeReview.Services;
using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;

namespace CodeReview.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var viewModel = new ComparerViewModel();

            viewModel.DirectoryOriginal = new CodeDirectory(@"C:\Users\Eyassu\Documents\CodeReviewTest\Comparison\BLL Legacy");
            viewModel.RefactorDirectory = @"C:\Users\Eyassu\Documents\CodeReviewTest\Comparison\New\BLL";
            viewModel.QueriesDirectory = @"C:\Users\Eyassu\Documents\CodeReviewTest\Comparison\New\Repository\HCMIS.Repository\Queries";
            viewModel.OutputDirectory = new DirectoryInfo(@"C:\Users\Eyassu\Documents\CodeReviewTest\Comparison");

            viewModel.CompareDirectories();
            

            //viewModel.File1 = @"C:\Users\henok\Desktop\Comparison\BLL Legacy\Models\ItemUnit.cs";
            //viewModel.File2 = @"C:\Users\henok\Desktop\Comparison\New\BLL\Models\ItemUnit.cs";
            
            //var result = viewModel.Compare();
            //if (result.HaveIdenticalMethods())
            //    System.Console.WriteLine("Have Identical Methods");
            //if(result.HaveIdenticalVariables())
            //    System.Console.WriteLine("Have Identical variables");
            //System.Console.ReadLine();
        }
    }
}
