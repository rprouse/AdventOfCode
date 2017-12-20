using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public static class MatchExtenstions
    {
        public static int GetInt(this Match m, string group, int def = 0) =>
            m.Groups[group]?.Value.ToInt() ?? def;

        public static long GetLong(this Match m, string group, long def = 0) =>
            m.Groups[group]?.Value.ToLong() ?? def;
    }
}
