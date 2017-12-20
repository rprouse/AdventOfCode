namespace AdventOfCode2017
{
    public static class StringExtensions
    {
        public static int ToInt(this string str, int def = 0)
        {
            int i = def;
            int.TryParse(str, out i);
            return i;
        }

        public static long ToLong(this string str, long def = 0)
        {
            long l = def;
            long.TryParse(str, out l);
            return l;
        }
    }
}
