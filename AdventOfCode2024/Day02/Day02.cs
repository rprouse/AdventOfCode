using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2024;

public static class Day02
{
    public static int PartOne(string filename)
    {
        List<int[]> lists = filename
            .ReadAllLines()
            .Select(line => line.Split(' ')
            .Select(int.Parse).ToArray())
            .ToList();

        int count = 0;
        foreach (int[] arr in lists)
        {
            if (arr[0] == arr[1]) continue;
            bool safe = true;
            bool increasing = arr[0] < arr[1];
            for (int i = 1; i < arr.Length; i++)
            {
                if (increasing == arr[i - 1] > arr[i])
                {
                    safe = false;
                    break;
                }
                if (arr[i - 1] == arr[i] || Math.Abs(arr[i - 1] - arr[i]) > 3)
                {
                    safe = false;
                    break;
                }
            }
            if (safe) count++;
        }
        return count;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
