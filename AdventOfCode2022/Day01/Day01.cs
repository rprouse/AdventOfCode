using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day01
{
    public static int PartOne(string filename)
    {
        string[] lines = filename.ReadAllLinesIncludingBlank();
        var calories = new List<int>();
        int count = 0;
        foreach ( string line in lines )
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                calories.Add(count);
                count = 0;
                continue;
            }
            count += line.ToInt();
        }
        calories.Add(count);
        return calories.Max();
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLinesIncludingBlank();
        return 0;
    }
}
