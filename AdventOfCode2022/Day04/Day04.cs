using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day04
{
    public static int PartOne(string filename)
    {
        string[] lines = filename.ReadAllLines();
        int count = 0;
        foreach (string line in lines)
        {
            var parts = line.Split(',');
            var r1 = GetRange(parts[0]);
            var r2 = GetRange(parts[1]);
            if (r1.Contains(r2) || r2.Contains(r1))
                count++;
        }
        return count;
    }

    static Range GetRange(string str)
    {
        var parts = str.Split('-');
        return new Range(parts[0].ToInt(), parts[1].ToInt());
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }

    internal record Range(int Min, int Max)
    {
        public bool Contains(Range r2) =>
            Min <= r2.Min && Max >= r2.Max;
    }
}
