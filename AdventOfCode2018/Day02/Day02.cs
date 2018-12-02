using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day02
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return lines.Count(l => ContainsNumberOfCharacters(l, 2)) *
                   lines.Count(l => ContainsNumberOfCharacters(l, 3)); ;
        }

        internal static bool ContainsNumberOfCharacters(string line, int n)
        {
            foreach (char c in line)
            {
                if (line.Count(c1 => c1 == c) == n)
                    return true;
            }
            return false;
        }

        public static string PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return DifferenceInMatchingPair(lines);
        }

        internal static string DifferenceInMatchingPair(string[] lines)
        {
            // Line length
            int ll = lines[0].Length;

            // Loop through number of chars of difference
            foreach(int i in Enumerable.Range(1, ll))
            {
                // Loop through lines in the file
                foreach(int l in Enumerable.Range(0, lines.Length - 1))
                {
                    // Candidate code
                    string c = lines[l];
                    for(int m = l + 1; m < lines.Length; m++)
                    {
                        string diff = Difference(c, lines[m]);
                        if (diff.Length == (ll - i))
                            return diff;
                    }
                }
            }
            return "";
        }

        internal static string Difference(string a, string b)
        {
            var sb = new StringBuilder();
            for(int i = 0; i < a.Length && i < b.Length; i++)
            {
                if (a[i] == b[i])
                    sb.Append(a[i]);
            }
            return sb.ToString();
        }
    }
}
