using System;
using System.Collections.Generic;
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
            bool safe = true;
            bool increasing = arr[0] < arr[1];
            for (int i = 1; i < arr.Length; i++)
            {
                if (increasing == arr[i - 1] > arr[i] ||
                    arr[i - 1] == arr[i] ||
                    Math.Abs(arr[i - 1] - arr[i]) > 3)
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
        List<int[]> lists = filename
            .ReadAllLines()
            .Select(line => line.Split(' ')
            .Select(int.Parse).ToArray())
            .ToList();

        int count = 0;
        foreach (int[] arr in lists)
        {
            for (int s = 0; s < arr.Length; s++)
            {
                bool safe = true;
                bool increasing = s switch
                {
                    0 => arr[1] < arr[2],
                    1 => arr[0] < arr[2],
                    _ => arr[0] < arr[1]
                };

                for (int i = 1; i < arr.Length; i++)
                {
                    if (i - 1 == s)
                    {
                        if (s > 0 &&
                            (increasing == arr[i - 2] > arr[i] ||
                             arr[i - 2] == arr[i] ||
                             Math.Abs(arr[i - 2] - arr[i]) > 3))
                        {
                            safe = false;
                        }
                    }
                    else if (i != s &&
                        (increasing == arr[i - 1] > arr[i] ||
                         arr[i - 1] == arr[i] ||
                         Math.Abs(arr[i - 1] - arr[i]) > 3))
                    {
                        safe = false;
                        break;
                    }
                }
                if (safe)
                {
                    count++;
                    break;
                }
            }
        }
        return count;
    }
}
