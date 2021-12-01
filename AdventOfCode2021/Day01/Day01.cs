using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day01
{
    public static int PartOne(string filename)
    {
        int[] depths = filename.GetInts();
        int count = 0;
        for (int i = 0; i < depths.Length - 1; i++)
        {
            if (depths[i] < depths[i + 1]) count++;
        }
        return count;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}

