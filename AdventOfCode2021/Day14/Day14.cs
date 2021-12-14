using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day14
{
    public static long PartOne(string filename) =>
        BuildPolymer(filename, 10);

    public static long PartTwo(string filename) =>
        BuildPolymer(filename, 40);

    internal static long BuildPolymer(string filename, int steps)
    { 
        // Parse File
        string[] lines = filename.ReadAllLinesIncludingBlank();
        string polymer = lines[0];
        var rules = new Dictionary<string, string>();
        foreach (string line in lines.Skip(2))
        {
            var parts = line.Split(" -> ");
            rules.Add(parts[0], parts[1]);
        }

        // Run 10 steps
        StringBuilder sb = new StringBuilder();
        for (int step = 0; step < steps; step++)
        {
            sb.Clear();
            sb.Append(polymer[0]);
            for (int i = 0; i < polymer.Length - 1; i++)
            {
                var pair = polymer.Substring(i, 2);
                sb.Append(rules[pair]);
                sb.Append(polymer[i + 1]);
            }
            polymer = sb.ToString();
        }

        // Count Elements
        long min = long.MaxValue;
        long max = 0;
        foreach(char c in polymer.Distinct())
        {
            int count = polymer.Count(c1 => c1 == c);
            if(count < min) min = count;
            if(count > max) max = count;
        }
        return max - min;
    }
}
