namespace AdventOfCode.Core
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to an int
        /// </summary>
        /// <param name="str"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static int ToInt(this string str, int def = 0) =>
            int.TryParse(str, out int i) ? i : def;

        /// <summary>
        /// Converts a string to a long
        /// </summary>
        /// <param name="str"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static long ToLong(this string str, long def = 0) =>
            long.TryParse(str, out long l) ? l : def;
    }
}
