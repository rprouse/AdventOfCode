using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

using Rules = System.Collections.Generic.Dictionary<string, string>;

namespace AdventOfCode2021;

public static class Day14
{
    public static long PartOne(string filename) =>
        BuildPolymer(filename, 10);

    public static long PartTwo(string filename) =>
        BuildPolymer(filename, 40);

    internal static long BuildPolymer(string filename, int steps)
    {
        (string polymer, Rules rules) = ParseInput(filename);
        return RunSteps(steps, polymer, rules);
    }

    private static (string polymer, Rules rules) ParseInput(string filename)
    {
        string[] lines = filename.ReadAllLinesIncludingBlank();
        string polymer = lines[0];
        var rules = new Rules();
        foreach (string line in lines.Skip(2))
        {
            var parts = line.Split(" -> ");
            rules.Add(parts[0], parts[1]);
        }
        return (polymer, rules);
    }

    private static long RunSteps(int steps, string polymer, Dictionary<string, string> rules)
    {
        var pairs = new Dictionary<string, long>();
        for (int i = 0; i < polymer.Length - 1; i++)
        {
            var pair = polymer.Substring(i, 2);
            if (!pairs.ContainsKey(pair)) pairs.Add(pair, 0);
            pairs[pair]++;
        }

        for (int step = 0; step < steps; step++)
        {
            var newPairs = new Dictionary<string, long>();

            foreach (var key in pairs.Keys)
            {
                var np1 = key[0] + rules[key];
                var np2 = rules[key] + key[1];

                if (!newPairs.ContainsKey(np1)) newPairs.Add(np1, 0);
                if (!newPairs.ContainsKey(np2)) newPairs.Add(np2, 0);

                newPairs[np1] += pairs[key];
                newPairs[np2] += pairs[key];
            }
            pairs = newPairs;
        }

        // Count chars
        var count = new Dictionary<char, long>();
        foreach (var pair in pairs)
        {
            var c1 = pair.Key[0];
            var c2 = pair.Key[1];

            if (!count.ContainsKey(c1)) count.Add(c1, 0);
            if (!count.ContainsKey(c2)) count.Add(c2, 0);

            count[c1] += pair.Value;
            count[c2] += pair.Value;
        }
        count[polymer.Last()]++;
        long min = count.Min(c => c.Value);
        long max = count.Max(c => c.Value);
        return (max - min) / 2;
    }
}
