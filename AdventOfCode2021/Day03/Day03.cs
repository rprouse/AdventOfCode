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
        return 0;
    }
}
