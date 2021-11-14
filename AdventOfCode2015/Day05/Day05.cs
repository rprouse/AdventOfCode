using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day05
    {
        public static int PartOne(string filename) =>
            filename.ReadAllLines()
                .Count(line => NaughtyOrNice(line));

        internal static bool NaughtyOrNice(string str)
        {
            if (str.Contains("ab") ||
                str.Contains("cd") ||
                str.Contains("pq") ||
                str.Contains("xy")) return false;

            return (CountVowels(str) >= 3) &&
                HadDoubleLetter(str);
        }

        internal static int CountVowels(string str) =>
            str.Count(c => "aeiou".Contains(c));

        internal static bool HadDoubleLetter(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
                if (str[i] == str[i + 1]) return true;

            return false;
        }

        public static int PartTwo(string filename) =>
            filename.ReadAllLines()
                .Count(line => NaughtyOrNiceV2(line));

        internal static bool NaughtyOrNiceV2(string str) =>
            ContainsTwoPairs(str) && ContainsRepeat(str);

        internal static bool ContainsTwoPairs(string str)
        {
            for (int i = 0; i <= str.Length - 3; i++)
            {
                for (int j = i + 2; j <= str.Length - 2; j++)
                {
                    if (str[j] == str[i] && str[j + 1] == str[i + 1])
                        return true;
                }
            }
            return false;
        }

        internal static bool ContainsRepeat(string str)
        {
            for (int i = 0; i <= str.Length - 3; i++)
            {
                if(str[i] == str[i + 2])
                    return true;
            }
            return false;
        }
    }
}
