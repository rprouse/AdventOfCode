using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day06
{
    public static int PartOne(string filename) =>
        ReproduceFishForDays(filename.SplitInts().ToList(), 80);

    public static int ReproduceFishForDays(IList<int> fish, int days)
    {
        Enumerable.Range(0, days)
            .ForEach(_ => 
            {
                var generation = new List<int>(fish.Count);
                foreach(int f in fish)
                {
                    if(f == 0)
                    {
                        generation.Add(6);
                        generation.Add(8);
                    }
                    else
                    {
                        generation.Add(f-1);
                    }
                }
                fish = generation;
            });
        return fish.Count;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
