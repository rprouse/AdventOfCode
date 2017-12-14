using System;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public static class ProgramEntry
    {
        public static async Task Main()
        {
            Day14.Visualize = true;
            await Day14.PartTwo("hwlqcszp");

            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
