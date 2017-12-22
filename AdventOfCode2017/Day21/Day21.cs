using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public static class Day21
    {
        public static int PartOne(string filename, int iterations)
        {
            var rules = AddTransformationsToRules(GetRules(filename));
            var matrix = ".#./..#/###";
            foreach (int i in Enumerable.Range(0, iterations))
            {
                matrix = matrix.Transform(rules);
            }
            return matrix.Count(c => c == '#');
        }

        public static Dictionary<string, string> GetRules(string filename) =>
            File.ReadAllLines(filename)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Split(" => "))
                .ToDictionary(s => s[0], s => s[1]);

        public static Dictionary<string, string> AddTransformationsToRules(Dictionary<string, string> rules)
        {
            var copy = new Dictionary<string, string>(rules.Count*5);
            foreach (var pair in rules)
            {
                string group = pair.Key;
                copy[group] = pair.Value;
                foreach (int i in Enumerable.Range(0, 4))
                {
                    group = Symmetric(group);
                    copy[group] = pair.Value;

                    group = Flip(group);
                    copy[group] = pair.Value;
                }
            }
            return copy;
        }

        public static string Transform(this string matrix, Dictionary<string, string> rules) =>
            matrix.BreakupMatrix()
                  .Select(g => rules[g])
                  .JoinMatrixes();

        public static string Symmetric(string m) =>
            m.Length == 11 ? $"{m[0]}{m[4]}{m[8]}/{m[1]}{m[5]}{m[9]}/{m[2]}{m[6]}{m[10]}" :
                             $"{m[0]}{m[3]}/{m[1]}{m[4]}";

        public static string Flip(string m) =>
            m.Length == 11 ? $"{m[8]}{m[9]}{m[10]}/{m[4]}{m[5]}{m[6]}/{m[0]}{m[1]}{m[2]}" :
                             $"{m[3]}{m[4]}/{m[0]}{m[1]}";

        public static IEnumerable<string> BreakupMatrix(this string matrix)
        {
            string[] rows = matrix.Split('/');
            int divisor = rows.Length % 2 == 0 ? 2 : 3;
            int numGroups = (int)Math.Pow(rows.Length / divisor, 2);
            int groupSize = rows.Length / divisor;
            for (int g = 0; g < numGroups; g++)
            {
                var sb = new StringBuilder();
                for (int y = 0; y < divisor; y++)
                {
                    for (int x = 0; x < divisor; x++)
                    {
                        sb.Append(rows[(g / groupSize) * divisor + y][(g % groupSize) * divisor + x]);
                    }
                    if (y != divisor - 1) sb.Append('/');
                }
                yield return sb.ToString();
            }
        }

        public static string JoinMatrixes(this IEnumerable<string> children)
        {
            string[][] groups = children.Select(s => s.Split('/')).ToArray();
            var divisor = groups[0][0].Length;
            var size = (int)Math.Sqrt(groups.Length * divisor * divisor);
            var sb = new StringBuilder();
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    sb.Append(groups[(y / divisor) * (size/divisor) + x / divisor][y % divisor][x % divisor]);
                }
                if (y != size - 1) sb.Append('/');
            }
            return sb.ToString();
        }
    }
}
