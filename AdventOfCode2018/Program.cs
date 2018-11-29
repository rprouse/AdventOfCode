using System;
using System.Threading.Tasks;
using NUnit.Framework;

[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace AdventOfCode2018
{
    public static class ProgramEntry
    {
        public static async Task Main()
        {
            Console.ResetColor();
            Console.ReadLine();

            await Task.FromResult(false);
        }
    }
}
