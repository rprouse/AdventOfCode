using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day01
{
    public static int PartOne(string filename)
    {
        int[] depths = filename.GetInts();
        return Enumerable
            .Range(0, depths.Length - 1)
            .Count(i => depths[i] < depths[i + 1]);
    }

    public static int PartTwo(string filename)
    {
        int[] depths = filename.GetInts();
        return Enumerable
            .Range(0, depths.Length - 3)
            .Count(i => depths[i] + depths[i + 1] + depths[i + 2] < 
                        depths[i + 1] + depths[i + 2] + depths[i + 3]);
    }
}

