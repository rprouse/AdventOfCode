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
            //Day10.PartOne(TestBase.TestFile(10), 0);
            //Day10.PartOne(TestBase.PuzzleFile(10), 10124);
            //Day13.PartOne(TestBase.PuzzleFile(13));
            Day13.PartOne(TestBase.TestFile(13));

            //Console.ResetColor();
            //Console.ReadLine();

            await Task.FromResult(false);
        }
    }
}
