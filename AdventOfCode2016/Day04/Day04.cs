using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public static class Day04
    {
        public static int PartOne(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            return 0;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            return 0;
        }
    }
}
