using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public static class Day06
    {
        public static string PartOne(string filename) =>
            Decrypt(filename, MostCommonChar);

        public static string PartTwo(string filename) =>
            Decrypt(filename, LeastCommonChar);

        internal static string Decrypt(string filename, Func<IEnumerable<string>, int, char> decryptor)
        {
            string[] lines = filename.ReadAllLines();
            char[] c = Enumerable.Range(0, lines[0].Length)
                .Select(i => decryptor(lines, i))
                .ToArray();
            return new string(c);
        }

        internal static char MostCommonChar(IEnumerable<string> lines, int pos)
        {
            var counts = CountCharacters(lines, pos);
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

        internal static char LeastCommonChar(IEnumerable<string> lines, int pos)
        {
            var counts = CountCharacters(lines, pos);
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

        private static Dictionary<char, int> CountCharacters(IEnumerable<string> lines, int pos)
        {
            var counts = new Dictionary<char, int>();
            foreach (char c in lines.Select(l => l[pos]))
            {
                if (!counts.ContainsKey(c))
                    counts[c] = 1;
                else
                    counts[c]++;
            }

            return counts;
        }
    }
}
