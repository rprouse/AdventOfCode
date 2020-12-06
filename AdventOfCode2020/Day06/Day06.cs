using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day06
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLinesIncludingBlank();
            var answers = ParseFileOne(lines);
            return answers.Sum(g => g.Count(a => a));
        }

        public static int PartTwo(string filename) =>
            ParseFileTwo(filename.ReadAllLinesIncludingBlank()).Sum();

        static IList<bool[]> ParseFileOne(string[] lines)
        {
            IList<bool[]> ret = new List<bool[]>();
            bool[] answers = new bool[26];
            ret.Add(answers);
            foreach(string line in lines)
            {
                if(string.IsNullOrEmpty(line))
                {
                    answers = new bool[26];
                    ret.Add(answers);
                    continue;
                }
                foreach(char c in line)
                {
                    answers[c - 'a'] = true;
                }
            }
            return ret;
        }

        static IEnumerable<int> ParseFileTwo(string[] lines)
        {
            var one = new List<char>(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    yield return one.Count();
                    one = new List<char>("abcdefghijklmnopqrstuvwxyz");
                    continue;
                }
                one = one.Intersect(new List<char>(lines[i])).ToList();
            }
            yield return one.Count();
        }
    }
}
