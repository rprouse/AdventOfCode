using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public static class Day21
    {
        public const string START_IMAGE = ".#./..#/###";

        public static int PartOne(string filename, int iterations)
        {
            var rules = GetRules(filename);
            var matrix = START_IMAGE;
            for(int i = 0; i < iterations; i++)
            {
                matrix = matrix.Transform(rules);
            }
            return matrix.Count(c => c == '#');
        }

        public static int PartTwo(string filename)
        {
            var rules = GetRules(filename);
            return 0;
        }

        public static Dictionary<string,string> GetRules(string filename) =>
            File.ReadAllLines(filename)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Split(" => "))
                .ToDictionary(s => s[0], s => s[1]);

        public static string Transform(this string matrix, Dictionary<string, string> rules)
        {
            return matrix;
        }

        public static IEnumerable<string> BreakupMatrix(this string matrix)
        {
            string[] rows = matrix.Split('/');
            int divisor = rows.Length % 2 == 0 ? 2 : 3;
            int numGroups = (int)Math.Pow(rows.Length / divisor, 2);
            for(int g = 0; g < numGroups; g++ )
            {
                var sb = new StringBuilder();
                for (int y = 0; y < divisor; y++)
                {
                    for (int x = 0; x < divisor; x++)
                    {
                        sb.Append(rows[(g/divisor)*divisor+y][(g%divisor)*divisor+x]);
                    }
                    if (y != divisor - 1) sb.Append('/');
                }
                yield return sb.ToString();
            }
        }

        public static string JoinMatrixes(this string[] children)
        {
            string[][] groups = children.Select(s => s.Split('/')).ToArray();
            var divisor = groups[0][0].Length;
            var size = (int)Math.Sqrt(groups.Length * divisor * divisor);
            var sb = new StringBuilder();
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    sb.Append(groups[(y / divisor) * divisor + x / divisor][y % divisor][x % divisor]);
                }
                if (y != size - 1)
                    sb.Append('/');
            }
            return sb.ToString();
        }

        public static string FlipV(this string matrix)
        {
            string[] rows = matrix.Split('/');
            string[] ret = new string[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                ret[rows.Length - i - 1] = rows[i];
            }
            return string.Join('/', ret);
        }

        public static string FlipH(this string matrix)
        {
            string[] rows = matrix.Split('/');
            string[] ret = new string[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                var row = new StringBuilder(rows.Length);
                for (int j = 0; j < rows.Length; j++)
                {
                    row.Append(rows[i][rows.Length - j - 1]);
                }
                ret[i] = row.ToString();
            }
            return string.Join('/', ret);
        }

        public static string Rotate(this string matrix)
        {
            string[] rows = matrix.Split('/');
            string[] ret = new string[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                var row = new StringBuilder(rows.Length);
                for (int j = 0; j < rows.Length; j++)
                {
                    row.Append(rows[rows.Length - j - 1][i]);
                }
                ret[i] = row.ToString();
            }
            return string.Join('/', ret);
        }
    }
}
