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
        int min = crabs.Min();
        int max = crabs.Max();
        int fuel = int.MaxValue;
        for (int i = min; i <= max; i++)
        {
            int sum = crabs.Select(x => fuelRate(i - x)).Sum();
            if (sum < fuel)
                fuel = sum;
        }
        return fuel;
    }

    // Uses the triangle number sequence
    // where x(n) = n(n+1)/2
    internal static int CalculateFuel(int steps)
    {
        steps = Math.Abs(steps);
        return steps * (steps + 1) / 2;
    }

}
