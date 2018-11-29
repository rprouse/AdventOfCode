using System;
using System.Threading.Tasks;
using AdventOfCode.Core;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace AdventOfCode2016
{
    public static class ProgramEntry
    {
        public static async Task Main()
        {
            var day = new Day07(50, 6);
            string[] lines = TestBase.PuzzleFile(07).ReadAllLines();
            foreach (var line in lines)
            {
                Console.Clear();

                Console.WriteLine(line);
                Console.WriteLine();
                day.ParseLine(line);
                Console.WriteLine(day.ToString());
                Console.WriteLine();
            }
            Console.WriteLine($"Pixels = {day.LitPixels}");

            Console.ResetColor();
            Console.ReadLine();

            await Task.FromResult(false);
        }
    }
}
