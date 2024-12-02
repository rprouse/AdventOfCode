using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2024;

public static class Day01
{
    public static int PartOne(string filename)
    {
        int[][] values = filename
            .ReadAllLines()
            .Select(l =>
            {
                string[] pair = l.Split(' ', options: StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                int[] values = [
                    int.Parse(pair[0]),
                    int.Parse(pair[1])
                ];
                return values;
            })
            .ToArray();

        int[] list1 = values.Select(values => values[0]).Order().ToArray();
        int[] list2 = values.Select(values => values[1]).Order().ToArray();
        int sum = 0;
        for (int i = 0; i < list1.Length; i++)
        {
            sum += Math.Abs(list1[i] - list2[i]);
        }

        return sum;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
