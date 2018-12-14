using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day12
    {
        public static int PartOne(string filename, string initialState)
        {
            var rules = ParseRules(filename);

            var sb = new StringBuilder(".....");
            sb.Append(initialState);
            sb.Append(".....");
            var pots = sb.ToString();

            foreach (int gen in Enumerable.Range(0, 20))
            {
                sb = new StringBuilder(".....");
                for (int i = 2; i < pots.Length - 2; i++)
                {
                    var compare = pots.Substring(i - 2, 5);
                    sb.Append(rules.Any(r => r == compare) ? '#' : '.');
                }
                sb.Append(".....");
                pots = sb.ToString();
            }
            int offset = (pots.Length - initialState.Length) / 2;
            int sum = 0;
            for(int i = 0; i < pots.Length; i++)
            {
                if (pots[i] == '#')
                    sum += i - offset;
            }
            return sum;
        }

        private static string[] ParseRules(string filename) =>
            filename.ReadAllLines()
                .Where(l => l.EndsWith("#"))
                .Select(l => l.Substring(0, 5))
                .ToArray();

        private static char[] EmptyPots()
        {
            var pots = new char[150];
            Enumerable.Range(0, 150).ForEach(i => pots[i] = '.');
            return pots;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
