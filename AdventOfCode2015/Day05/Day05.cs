using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day05
    {
        public static int PartOne(string filename) =>
            filename.ReadAllLines()
                .Count(line => NaughtyOrNice(line));

        public static bool NaughtyOrNice(string str)
        {
            if (str.Contains("ab") ||
                str.Contains("cd") ||
                str.Contains("pq") ||
                str.Contains("xy")) return false;

            return (CountVowels(str) >= 3) && 
                HadDoubleLetter(str);
        }

        public static int CountVowels(string str) =>
            str.Count(c => "aeiou".Contains(c));

        public static bool HadDoubleLetter(string str)
        {
            for(int i = 0; i < str.Length - 1; i++)
                if (str[i] == str[i + 1]) return true;

            return false;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
