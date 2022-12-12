using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Core;

public static class AocMath
{
    public static uint GreatestCommonFactor(uint a, uint b)
    {
        while (b != 0)
        {
            uint temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static ulong LeastCommonMultiple(uint a, uint b) =>
        a * b / GreatestCommonFactor(a, b);

    public static ulong GreatestCommonFactor(ulong a, ulong b)
    {
        while (b != 0)
        {
            ulong temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static ulong LeastCommonMultiple(ulong a, ulong b) =>
        a * b / GreatestCommonFactor(a, b);

    public static ulong LeastCommonMultiple(IEnumerable<uint> values)
    {
        uint[] sorted = values.OrderByDescending(v => v).ToArray();
        uint multiple = 1;
        while (true)
        {
            ulong canditate = sorted[0] * multiple++;
            bool allMultiples = true;
            for (int i = 1; i < sorted.Length; i++)
            {
                if (canditate % sorted[i] != 0)
                {
                    allMultiples = false;
                    break;
                }
            }
            if (allMultiples) return canditate;
        }
    }
}
