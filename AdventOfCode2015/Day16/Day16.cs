using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015;

public static partial class Day16
{
    public static int PartOne(string filename) =>
        filename.ReadAllLines()
            .Select(l => new Aunt(l))
            .Where(a => a.Matches())
            .First()
            .Number;

    public static int PartTwo(string filename) =>
        filename.ReadAllLines()
            .Select(l => new Aunt(l))
            .Where(a => a.MatchesRetroEncabulator())
            .First()
            .Number;
}
