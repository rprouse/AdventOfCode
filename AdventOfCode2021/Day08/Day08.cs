using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day08
{
    public static int PartOne(string filename)
    {
        string[] lines = filename.ReadAllLines();
        int count = 0;
        foreach (string line in lines)
        {
            string[] parts = line.Split(" | ");
            string[] input = parts[0].Split(' ');
            string[] output = parts[1].Split(' ');
            count += output.Count(o => o.Length == 2 || o.Length == 4 || o.Length == 3 || o.Length == 7);
        }
        return 0;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
