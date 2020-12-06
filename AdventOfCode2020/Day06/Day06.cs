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
            var one = new List<char>(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    yield return one.Count();
                    one = new List<char>();
                    continue;
                }
                one = one.Union(new List<char>(lines[i])).ToList();
            }
            yield return one.Count();
        }

        static IEnumerable<int> ParseFileTwo(string[] lines)
        {
            var one = new List<char>(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    yield return one.Count();
                    one = new List<char>("abcdefghijklmnopqrstuvwxyz");
                    continue;
                }
                one = one.Intersect(new List<char>(lines[i])).ToList();
            }
            yield return one.Count();
        }
    }
}
