using System;
using System.Threading.Tasks;
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
            Day23.PartOne("389125467", 10, true);

            Console.ResetColor();
            Console.ReadLine();

            await Task.FromResult(false);
        }
    }
}