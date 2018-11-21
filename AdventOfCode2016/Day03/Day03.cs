using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public static class Day03
    {
        public static int PartOne(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            int valid = 0;
            foreach(var line in lines)
            {
                (int a, int b, int c) = ParseTriangle(line);
                if (IsValidTriangle(a, b, c))
                    valid++;
            }
            return valid;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            return 0;
        }

        public static (int, int, int) ParseTriangle(string input)
        {
            int.TryParse(input.Substring(0, 5), out int a);
            int.TryParse(input.Substring(5, 5), out int b);
            int.TryParse(input.Substring(10, 5), out int c);

            return (a, b, c);
        }

        public static bool IsValidTriangle(int a, int b, int c)
        {
            if (a + b <= c) return false;
            if (a + c <= b) return false;
            if (c + b <= a) return false;
            return true;
        }
    }
}
