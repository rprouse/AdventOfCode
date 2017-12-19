using System;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

[assembly:Parallelizable(ParallelScope.All)]

namespace AdventOfCode2017
{
    public static class ProgramEntry
    {
        public static async Task Main()
        {
            //Day14.Visualize = true;
            //await Day14.PartTwo("hwlqcszp");
            
            Day19.PartOne("Day19\\Data.txt");

            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
