using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day07
{
    public static int PartOne(string filename)
    {
        int[] crabs = filename.SplitInts();
        int min = crabs.Min();
        int max = crabs.Max();
        int fuel = int.MaxValue;
        for (int i = min; i <= max; i++)
        {
            int sum = crabs.Select(x => Math.Abs(i-x)).Sum();
            if (sum < fuel)
                fuel = sum;
        }
        return fuel;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
