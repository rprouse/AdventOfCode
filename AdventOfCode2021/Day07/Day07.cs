using System;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day07
{
    public static int PartOne(string filename) =>
        CalculateFuel(filename, dist => Math.Abs(dist));

    public static int PartTwo(string filename) =>
        CalculateFuel(filename, dist => CalculateFuel(dist));

    internal static int CalculateFuel(string filename, Func<int, int> fuelRate)
    {
        int[] crabs = filename.SplitInts();
        int start = crabs.Min();
        int count = crabs.Max() - start;

        return Enumerable
            .Range(start, count)
            .Min(i => crabs.Select(x => fuelRate(i - x)).Sum());
    }

    // Uses the triangle number sequence
    // where x(n) = n(n+1)/2
    internal static int CalculateFuel(int steps)
    {
        steps = Math.Abs(steps);
        return steps * (steps + 1) / 2;
    }

}
