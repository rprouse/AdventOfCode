using System;
using System.Threading.Tasks;
using NUnit.Framework;

[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace AdventOfCode2018
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.ResetColor();
            Console.ReadLine();

            await Task.FromResult(false);
        }
    }
}
