using System;
using System.Threading.Tasks;
using AdventOfCode.Core;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace AdventOfCode2021
{
    public static class ProgramEntry
    {
        public static async Task Main()
        {
            //Day24.PartTwo(TestBase.TestFile(24), true);

            Console.ResetColor();
            Console.ReadLine();

            await Task.FromResult(false);
        }
    }
}