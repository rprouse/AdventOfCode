using System;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static partial class Day04
{
    public static int PartOne(string filename) =>
        CalculateDifferences(filename, (r1, r2) =>
            r1.Contains(r2) || r2.Contains(r1));

    public static int PartTwo(string filename) =>
        CalculateDifferences(filename, (r1, r2) => 
            r1.Overlaps(r2) || r2.Overlaps(r1));

    internal static int CalculateDifferences(string filename, Func<Range, Range, bool> comparer)
    {
        return filename
            .ReadAllLines()
            .Select(ParseLine)
            .Count(ranges => comparer(ranges.r1, ranges.r2));
    }

    internal static (Range r1, Range r2) ParseLine(string line)
    {
        var parts = line.Split(',');
        return (Range.GetRange(parts[0]), Range.GetRange(parts[1]));
    }
}
