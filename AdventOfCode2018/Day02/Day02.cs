using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day02
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return lines.Count(l => ContainsPair(l)) *
                   lines.Count(l => ContainsTriple(l)); ;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        internal static bool ContainsPair(string line) =>
            ContainsNumberOfCharacters(line, 2);

        internal static bool ContainsTriple(string line) =>
            ContainsNumberOfCharacters(line, 3);

        private static bool ContainsNumberOfCharacters(string line, int n)
        {
            foreach (char c in line)
            {
                if (line.Count(c1 => c1 == c) == n)
                    return true;
            }
            return false;
        }
    }
}
