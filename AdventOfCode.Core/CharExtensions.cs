namespace AdventOfCode.Core
{
    public static class CharExtensions
    {
        /// <summary>
        /// Converts a char to the int it represents as an ASCII string,
        /// not it's ASCII value
        /// </summary>
        /// <param name="c"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static int ToInt(this char c, int def = 0) =>
            c.ToString().ToInt(def);
    }
}
