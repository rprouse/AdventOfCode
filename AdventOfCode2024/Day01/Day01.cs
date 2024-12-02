using System;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2024;

public static class Day01
{
    public static int PartOne(string filename)
    {
        int[] list1, list2;
        GetTwoLists(filename, out list1, out list2);
        int sum = 0;
        for (int i = 0; i < list1.Length; i++)
        {
            sum += Math.Abs(list1[i] - list2[i]);
        }

        return sum;
    }

    public static int PartTwo(string filename)
    {
        int[] list1, list2;
        GetTwoLists(filename, out list1, out list2);
        int sum = 0;
        for (int i = 0; i < list1.Length; i++)
        {
            sum += list1[i] * list2.Count(l => list1[i] == l);
        }

        return sum;
    }

    private static void GetTwoLists(string filename, out int[] list1, out int[] list2)
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

        list1 = values.Select(values => values[0]).Order().ToArray();
        list2 = values.Select(values => values[1]).Order().ToArray();
    }
}
