using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day06
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLinesIncludingBlank();
            var answers = ParseFile(lines);
            return answers.Sum(g => g.Count(a => a));
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLinesIncludingBlank();
            return 0;
        }

        static IList<bool[]> ParseFile(string[] lines)
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
    }
}
