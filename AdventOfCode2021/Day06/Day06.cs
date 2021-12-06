using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day06
{
    public static long PartOne(string filename) =>
        ReproduceFishForDays(filename.SplitInts().ToList(), 80);

    public static long PartTwo(string filename) =>
        ReproduceFishForDays(filename.SplitInts().ToList(), 256);

    public static long ReproduceFishForDays(List<int> fish, int days)
    {
        long[] ages = new long[9];
        for(int day = 0; day <= 6; day++)
        {
            ages[day] = fish.Count(f => f == day);
        }
        Enumerable.Range(0, days)
            .ForEach(_ => 
            {
                long respawning = ages[0];
                for (int day = 0; day < 8; day++)
                {
                    ages[day] = ages[day + 1];
                }
                ages[6] += respawning;
                ages[8] = respawning;
            });
        return ages.Sum();
    }
}
