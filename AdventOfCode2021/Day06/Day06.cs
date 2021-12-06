using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day06
{
    public static long ReproduceFishForDays(IEnumerable<int> fish, int days)
    {
        // Copy number of fish at each age into an array where the
        // index equals the age in days
        long[] ages = new long[9];
        for (int day = 0; day <= 6; day++)
            ages[day] = fish.Count(f => f == day);
        
        // Loop through the generations. For each, shift the ages
        // left, then reset and respawn all currently at zero
        Enumerable.Range(0, days)
            .ForEach(_ =>
            {
                long respawning = ages[0];
                for (int day = 0; day < 8; day++)
                    ages[day] = ages[day + 1];
        
                ages[6] += respawning;
                ages[8] = respawning;
            });

        // How many fish are there?
        return ages.Sum();
    }
}
