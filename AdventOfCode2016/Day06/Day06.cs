using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public static class Day06
    {
        public static string PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            char[] c = Enumerable.Range(0, lines[0].Length)
                .Select(i => MostCommonChar(lines, i))
                .ToArray();
            return new string(c);
        }

        public static string PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            char[] c = Enumerable.Range(0, lines[0].Length)
                .Select(i => LeastCommonChar(lines, i))
                .ToArray();
            return new string(c);
        }

        public static char MostCommonChar(string[] lines, int pos)
        {
            var counts = new Dictionary<char, int>();
            foreach(char c in lines.Select(l => l[pos]))
            {
                if (!counts.ContainsKey(c))
                    counts[c] = 1;
                else
                    counts[c]++;
            }
            char maxc = char.MinValue;
            int maxv = -1;
            foreach (char c in counts.Keys)
            {
                if (counts[c] > maxv)
                {
                    maxc = c;
                    maxv = counts[c];
                }
            }
            return maxc;
        }

        public static char LeastCommonChar(string[] lines, int pos)
        {
            var counts = new Dictionary<char, int>();
            foreach (char c in lines.Select(l => l[pos]))
            {
                if (!counts.ContainsKey(c))
                    counts[c] = 1;
                else
                    counts[c]++;
            }
            char minc = char.MinValue;
            int minv = int.MaxValue;
            foreach (char c in counts.Keys)
            {
                if (counts[c] < minv)
                {
                    minc = c;
                    minv = counts[c];
                }
            }
            return minc;
        }
    }
}
