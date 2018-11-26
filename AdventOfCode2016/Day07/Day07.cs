using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public static class Day07
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return lines.Where(l => SupportsTLS(l)).Count();
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        public static bool SupportsTLS(string ipv7)
        {
            var sequences = GetHypernetSequences(ipv7);
            if (ContainsAbba(sequences))
                return false;

            var parts = StripHypernetSequences(ipv7);
            return ContainsAbba(parts);
        }

        private static bool ContainsAbba(IEnumerable<string> parts)
        {
            foreach (var part in parts)
            {
                for (int i = 0; i <= part.Length - 4; i++)
                {
                    if (SupportsTLS(part, i))
                        return true;
                }
            }
            return false;
        }

        static Regex sequences = new Regex(@"\[(\w+)\]", RegexOptions.Compiled);
        static Regex split = new Regex(@"\[\w+\]", RegexOptions.Compiled);

        internal static bool SupportsTLS(string ipv7, int i) =>
            ipv7[i] == ipv7[i + 3] &&
            ipv7[i + 1] == ipv7[i + 2] &&
            ipv7[i] != ipv7[i + 1];

        internal static string[] StripHypernetSequences(string ipv7) =>
            split.Split(ipv7);

        internal static IEnumerable<string> GetHypernetSequences(string ipv7)
        {
            var matches = sequences.Matches(ipv7);
            foreach(Match match in matches)
            {
                if (match.Success)
                    yield return match.Groups[1].Value;
            }
        }
    }
}
