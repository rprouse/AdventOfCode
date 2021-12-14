using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day14
{
    public static int PartOne(string filename)
    {
        // Parse File
        string[] lines = filename.ReadAllLinesIncludingBlank();
        string polymer = lines[0];
        var rules = new Dictionary<string, string>();
        foreach (string line in lines.Skip(2))
        {
            var parts = line.Split(" => ");
            rules.Add(parts[0], parts[1]);
        }

        // Run 10 steps
        StringBuilder sb = new StringBuilder();
        for (int steps = 0; steps < 10; steps++)
        {
            sb.Clear();
            sb.Append(polymer[0]);
            for (int i = 0; i < polymer.Length - 1; i++)
            {
                var pair = polymer.Substring(i, 2);
                sb.Append(rules[pair]);
                sb.Append(polymer[i + 1]);
            }
        }

        // Count Elements
        int min = int.MaxValue;
        int max = 0;
        foreach(char c in polymer.Distinct())
        {
            int count = polymer.Count(c1 => c1 == c);
            if(count < min) min = count;
            if(count > max) max = count;
        }
        return max - min;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
