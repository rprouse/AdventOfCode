using AdventOfCode.Core;

namespace AdventOfCode2022;

public static partial class Day04
{
    internal record Range(int Min, int Max)
    {
        public static Range GetRange(string str)
        {
            var parts = str.Split('-');
            return new Range(parts[0].ToInt(), parts[1].ToInt());
        }

        public bool Contains(Range r2) =>
            Min <= r2.Min && Max >= r2.Max;

        public bool Overlaps(Range r2) =>
            (Min >= r2.Min && Min <= r2.Max) ||
            (Max >= r2.Min && Max <= r2.Max);
    }
}
