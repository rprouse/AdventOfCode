using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day06
    {
        public static int PartOne(string filename) =>
            ParseFileOne(filename.ReadAllLinesIncludingBlank()).Sum();

        public static int PartTwo(string filename) =>
            ParseFileTwo(filename.ReadAllLinesIncludingBlank()).Sum();

        static IEnumerable<int> ParseFileOne(string[] lines)
        {
            IEnumerable<char> one = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    yield return one.Count();
                    one = string.Empty;
                    continue;
                }
                one = one.Union(lines[i]);
            }
            yield return one.Count();
        }

        static IEnumerable<int> ParseFileTwo(string[] lines)
        {
            IEnumerable<char> one = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    yield return one.Count();
                    one = "abcdefghijklmnopqrstuvwxyz";
                    continue;
                }
                one = one.Intersect(lines[i]);
            }
            yield return one.Count();
        }
    }
}
