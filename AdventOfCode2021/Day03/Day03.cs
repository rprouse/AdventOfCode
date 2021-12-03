using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day03
{
    public static int PartOne(string filename)
    {
        string[] lines = filename.ReadAllLines();
        int[] counts = new int[lines[0].Length];
        foreach (string line in lines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '1') counts[i]++;
            }
        }
        int half = lines.Length / 2;
        int gamma = 0;
        int epsilon = 0;
        for (int i = 0; i < counts.Length; i++)
        {
            if (counts[i] > half)
            {
                gamma += 1 << (counts.Length - i - 1);
            }
            else
            {
                epsilon += 1 << (counts.Length - i - 1);
            }
        }
        return gamma * epsilon;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return GetO2(lines) * GetCO2(lines);
    }

    private static int GetO2(string[] lines) =>
        GetValues(lines, (int count, double half, char c) =>
            (count >= half && c == '0') || (count < half && c == '1')
        );

    private static int GetCO2(string[] lines) =>
        GetValues(lines, (int count, double half, char c) =>
            (count < half && c == '0') || (count >= half && c == '1')
        );

    private static int GetValues(string[] lines, Func<int, double, char, bool> evaluator)
    {
        var candidates = new List<string>(lines);
        for (int i = 0; i < lines[0].Length; i++)
        {
            int count = candidates.Count(c => c[i] == '1');
            var half = candidates.Count / 2.0;

            lines.ForEach(line => 
            {
                if (candidates.Contains(line) && evaluator(count, half, line[i]))
                {
                    candidates.Remove(line);
                }
            });
            if (candidates.Count == 1) break;
        }
        return ConvertToBinary(candidates[0]);
    }

    private static int ConvertToBinary(string value)
    {
        int dec = 0;
        for (int i = 0; i < value.Length; i++)
        {
            if (value[i] == '1')
                dec += 1 << (value.Length - i - 1);
        }
        return dec;
    }
}
