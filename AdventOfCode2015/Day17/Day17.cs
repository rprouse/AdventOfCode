using System.Linq;
using AdventOfCode.Core;
using AdventOfCode.Core.DecisionProblems;

namespace AdventOfCode2015;

public static class Day17
{
    public static int PartOne(string filename, int target)
    {
        int[] containers = filename.GetInts();
        var subsetSum = new SubSetSum();
        var combinations = subsetSum.FindAllSubsets(containers, target);
        return combinations.Count;
    }

    public static int PartTwo(string filename, int target)
    {
        int[] containers = filename.GetInts().Order().ToArray();
        var subsetSum = new SubSetSum();
        var combinations = subsetSum.FindAllSubsets(containers, target);
        int min = combinations.Min(c => c.Length);
        return combinations.Count(c => c.Length == min);
    }
}