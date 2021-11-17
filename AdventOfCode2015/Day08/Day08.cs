using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day08
    {
        public static int PartOne(string filename) =>
            filename.ReadAllLines()
                .Sum(line => line.Length - CountCharacters(line));

        static Regex hex = new Regex(@"\\x\d\d",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        internal static int CountCharacters(string line)
        {
            //var hexMatches = hex.Matches(line);
            //line = line.Substring(1, line.Length - 2)
            //    .Replace("\\\"", "\"")
            //    .Replace("\\\\", "\\");
            //return line.Length - ( hexMatches.Count * 3);
            int count = 0;
            for (int i = 1; i < line.Length - 1; i++)
            {
                if (line[i] == '\\')
                {
                    if (line[i + 1] == '\\' || line[i + 1] == '\"')
                        i++;
                    else if (line[i + 1] == 'x' && IsHexChar(line[i + 2]) && IsHexChar(line[i + 3]))
                        i += 3;
                }
                count++;
            }
            return count;
        }

        internal static bool IsHexChar(char ch) =>
            char.IsDigit(ch) ||
            (ch >= 'a' && ch <= 'f') ||
            (ch >= 'A' && ch <= 'F');

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
