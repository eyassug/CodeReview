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
            viewModel.File1 = @"E:\Code\CodeReview\CodeReview.Services\ClassComparisonResult.cs";
            viewModel.File2 = @"E:\Code\CodeReview\CodeReview.Services\MethodComparisonResult.cs";
            var result = viewModel.Compare();
            if (result.HaveIdenticalMethods())
                System.Console.WriteLine("Have Identical Methods");
            if(result.HaveIdenticalVariables())
                System.Console.WriteLine("Have Identical variables");
            System.Console.ReadLine();
        }
    }
}
