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
            IEnumerable<char> one = string.Empty;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    yield return one.Count();
                    one = string.Empty;
                    continue;
                }
                one = one.Union(line);
            }
            yield return one.Count();
        }

        const string ALPHA = "abcdefghijklmnopqrstuvwxyz";
        static IEnumerable<int> ParseFileTwo(string[] lines)
        {
            IEnumerable<char> one = ALPHA;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    yield return one.Count();
                    one = ALPHA;
                    continue;
                }
                one = one.Intersect(line);
            }
            yield return one.Count();
        }
    }
}
