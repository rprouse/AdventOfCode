using System.Text.RegularExpressions;

namespace AdventOfCode.Core
{
    public static class MatchExtenstions
    {
        /// <summary>
        /// Gets an int from a named group in a regex match
        /// </summary>
        /// <param name="m"></param>
        /// <param name="group"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static int GetInt(this Match m, string group, int def = 0) =>
            m.Groups[group]?.Value.ToInt() ?? def;

        /// <summary>
        /// Gets a long from a named group in a regex match
        /// </summary>
        /// <param name="m"></param>
        /// <param name="group"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static long GetLong(this Match m, string group, long def = 0) =>
            m.Groups[group]?.Value.ToLong() ?? def;

        /// <summary>
        /// Gets an int from an unnamed group in a regex match
        /// </summary>
        /// <param name="m"></param>
        /// <param name="group"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static int GetInt(this Match m, int group, int def = 0) =>
            m.Groups[group].Value.ToInt(def);

        /// <summary>
        /// Gets a long from an unnamed group in a regex match
        /// </summary>
        /// <param name="m"></param>
        /// <param name="group"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static long GetLong(this Match m, int group, long def = 0) =>
            m.Groups[group].Value.ToLong(def);
    }
}
