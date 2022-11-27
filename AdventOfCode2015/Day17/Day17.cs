using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015;

public static class Day17
{
    public static int PartOne(string filename, int target)
    {
        int[] containers = filename.GetInts();
        var combinations = GenerateAllCombinations(containers, target);
        return combinations.Count;
    }

    public static int PartTwo(string filename)
    {
        int[] containers = filename.GetInts().Order().ToArray();
        return 0;
    }

    // Subset sum problem
    // https://en.wikipedia.org/wiki/Subset_sum_problem
    static List<int[]> GenerateAllCombinations(int[] arr, int target)
    {
        List<int[]> combinations = new List<int[]>();
        Queue<int> current = new Queue<int>();

        GetCombinations(arr.Order().ToArray(), 0, target, current, combinations);

        return combinations;
    }

    static void GetCombinations(int[] arr, int index, int target, Queue<int> current, List<int[]> combinations)
    {
        if (target == 0) 
        {
            combinations.Add(current.ToArray());
            return;
        }

        if (index == arr.Length || target < 0) return;

        int end = index;
        while (end < arr.Length && arr[end] == arr[index]) 
            end++;

        GetCombinations(arr, end, target, current, combinations);

        int count = 1;
        while (count <= end - index) 
        {
            current.Enqueue(arr[index]);
            GetCombinations(arr, end, target - count * arr[index], current, combinations);
            count++;
        }

        count = 1;
        while (count <= end - index) 
        {
            current.Dequeue();
            count++;
        }
    }
}
