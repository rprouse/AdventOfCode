using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day08
    {
        public static int PartOne(string filename) =>
            filename.ReadAllLines()
                .Sum(line => line.Length - CountCharacters(line));

        internal static int CountCharacters(string line)
        {
            return 0;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
