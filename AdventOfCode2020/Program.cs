using System;
using System.Threading.Tasks;
using AdventOfCode.Core;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace AdventOfCode2020
{
    public static class ProgramEntry
    {
        public static async Task Main()
        {
            //PlayBreakout();
            //WalkDroid();
            long result = Day23.PartTwo("247819356");
            Console.WriteLine(result);

            //Day24.PartTwo(TestBase.TestFile(24), true);

            Console.ResetColor();
            Console.ReadLine();

            await Task.FromResult(false);
        }
    }
}