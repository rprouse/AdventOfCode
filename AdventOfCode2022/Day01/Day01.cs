using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day01
{
    public static int PartOne(string filename) =>
        CountCalories(filename).Max();

    public static int PartTwo(string filename) =>
        CountCalories(filename)
            .OrderByDescending(i => i)
            .Take(3)
            .Sum();

    private static List<int> CountCalories(string filename)
    {
        string[] lines = filename.ReadAllLinesIncludingBlank();
        var calories = new List<int>();
        int count = 0;
        foreach (string line in lines)
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
        return calories;
    }
}
