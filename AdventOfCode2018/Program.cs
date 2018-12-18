using System;
using System.Threading.Tasks;
using AdventOfCode.Core;
using NUnit.Framework;

[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace AdventOfCode2018
{
    public static class ProgramEntry
    {
        public static async Task Main()
        {
            //Day15.PartOne(TestBase.TestFile(15, "Test1.txt"));
            //Day15.PartOne(TestBase.PuzzleFile(15));
            Day17.PartOne(TestBase.PuzzleFile(17));
                       
            Console.ResetColor();
            Console.ReadLine();

            await Task.FromResult(false);
        }
    }
}
