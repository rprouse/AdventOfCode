using System;
using System.Linq;
using System.Text;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day12
    {
        const string DOTS = "...";

        public static int PartOne(string filename, string initialState) =>
            RunGenerations(filename, initialState, 20).sum;


        public static long PartTwo(string filename, string initialState)
        {
            // 110 was derived starting with a larger number and looking at the
            // test output for each generation for the pattern where the sum
            // increased a specific amount every time. I then went 10 above that.
            (int sum, int diff) = RunGenerations(filename, initialState, 110);
            return (50000000000L - 110) * diff + sum;
        }

        public static (int sum, int diff) RunGenerations(string filename, string initialState, long generations)
        {
            var rules = ParseRules(filename);

            var sb = new StringBuilder(DOTS);
            sb.Append(initialState);
            sb.Append(DOTS);
            var pots = sb.ToString();
            int sum = SumPots(initialState, pots);
            int diff = 0;

            for (long gen = 0; gen < generations; gen++)
            {
                sb = new StringBuilder(pots.Length + 6);
                for (int i = 2; i < pots.Length - 2; i++)
                {
                    var compare = pots.Substring(i - 2, 5);
                    sb.Append(rules.Any(r => r == compare) ? '#' : '.');
                }
                pots = sb.ToString();
                var nextSum = SumPots(initialState, pots);
                diff = nextSum - sum;
                Console.WriteLine($"Gen: {gen} Sum: {nextSum} Diff: {diff}");
                sum = nextSum;
                if (!pots.StartsWith(DOTS) || !pots.EndsWith(DOTS))
                    pots = $"{DOTS}{pots}{DOTS}";
            }
            return (sum, diff);
        }

        private static int SumPots(string initialState, string pots)
        {
            int offset = (pots.Length - initialState.Length) / 2;
            int sum = 0;
            for (int i = 0; i < pots.Length; i++)
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
    }
}
