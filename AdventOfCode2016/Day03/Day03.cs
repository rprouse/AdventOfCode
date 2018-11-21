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
            int valid = 0;
            for (int i = 0; i < lines.Length - 2; i += 3)
            {
                (int a1, int b1, int c1) = ParseTriangle(lines[i]);
                (int a2, int b2, int c2) = ParseTriangle(lines[i+1]);
                (int a3, int b3, int c3) = ParseTriangle(lines[i+2]);
                if (IsValidTriangle(a1, a2, a3))
                    valid++;
                if (IsValidTriangle(b1, b2, b3))
                    valid++;
                if (IsValidTriangle(c1, c2, c3))
                    valid++;
            }
            return valid;
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
