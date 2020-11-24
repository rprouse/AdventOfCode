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
            //Day19.VisualizeTractorBeam();

            Console.ResetColor();
            Console.ReadLine();

            await Task.FromResult(false);
        }
    }
}