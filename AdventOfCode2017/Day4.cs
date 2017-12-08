using System.Linq;

namespace AdventOfCode2017
{
    public static class Day4
    {
        public static bool IsValid(this string passphrase)
        {
            var split = passphrase.Split(' ');
            return split.Distinct().Count() == split.Length;
        }
        public static bool IsAnagramValid(this string passphrase)
        {
            var split = passphrase
                          .Split(' ')
                          .Select(w => new string(w.ToCharArray().OrderBy(c => c).ToArray()));
            return split.Distinct().Count() == split.Count();
        }
    }
}
