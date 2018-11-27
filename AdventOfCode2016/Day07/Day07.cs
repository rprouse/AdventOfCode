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
            return lines.Where(l => SupportsSSL(l)).Count();
        }

        public static bool SupportsTLS(string ipv7)
        {
            var sequences = GetHypernetSequences(ipv7);
            if (ContainsAbba(sequences))
                return false;

            var parts = StripHypernetSequences(ipv7);
            return ContainsAbba(parts);
        }

        public static bool SupportsSSL(string ipv7)
        {
            var sequences = GetHypernetSequences(ipv7).ToArray();
            var parts = StripHypernetSequences(ipv7);

            foreach (var part in parts)
            {
                for (int i = 0; i <= part.Length - 3; i++)
                {
                    if(part[i] == part[i+2] && part[i] != part[i+1])
                    {
                        var bab = ConvertAbaToBab(part.Substring(i, 3));
                        if (sequences.Any(s => s.Contains(bab)))
                            return true;
                    }
                }
            }
            return false;
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
            foreach (Match match in matches)
            {
                if (match.Success)
                    yield return match.Groups[1].Value;
            }
        }

        internal static string ConvertAbaToBab(string aba)
        {
            if (aba.Length != 3)
                throw new ArgumentException("must be 3 chars", nameof(aba));
            char[] bab = new char[3];
            bab[0] = aba[1];
            bab[1] = aba[0];
            bab[2] = aba[1];
            return new string(bab);
        }
    }
}
