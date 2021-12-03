using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
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
        int len = lines[0].Length;
        var o2Candidates = new List<string>(lines);
        var co2Candidates = new List<string>(lines);
        for (int i = 0; i < len; i++)
        {
            int o2count = 0;
            foreach (string candidate in o2Candidates)
            {
                if (candidate[i] == '1') o2count++;
            }
            var o2half = o2Candidates.Count / 2.0;
            int co2count = 0;
            foreach (string candidate in co2Candidates)
            {
                if (candidate[i] == '1') co2count++;
            }
            var co2half = co2Candidates.Count / 2.0;

            foreach (string line in lines)
            {
                if (o2Candidates.Count > 1 && o2Candidates.Contains(line))
                {
                    if ((o2count >= o2half && line[i] == '0'))
                    {
                        o2Candidates.Remove(line);
                    }
                    if ((o2count < o2half && line[i] == '1'))
                    {
                        o2Candidates.Remove(line);
                    }
                }

                if (co2Candidates.Count > 1 && co2Candidates.Contains(line))
                {
                    if ((co2count < co2half && line[i] == '0'))
                    {
                        co2Candidates.Remove(line);
                    }
                    if ((co2count >= co2half && line[i] == '1'))
                    {
                        co2Candidates.Remove(line);
                    }
                }
            }
        }
        int o2 = 0;
        int co2 = 0;
        for (int i = 0; i < len; i++)
        {
            if (o2Candidates[0][i] == '1')
            {
                o2 += 1 << (len - i - 1);
            }
            
            if (co2Candidates[0][i] == '1')
            {
                co2 += 1 << (len - i - 1);
            }
        }
        return o2 * co2;
    }
}
