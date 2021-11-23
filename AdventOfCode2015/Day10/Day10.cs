using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day10
    {
        public static int PartOne(string input, int count)
        {
            for(int i = 0; i < count; i++)
                input = LookAndSay(input);

            return input.Length;
        }

        public static string LookAndSay(string input)
        {
            var result = new StringBuilder();
            for(int i = 0; i < input.Length;)
            {
                int j = 1;
                while(i + j < input.Length && input[i] == input[i + j])
                    j++;
                result.Append(j.ToString());
                result.Append(input[i]);
                i += j;
            }
            return result.ToString();
        }

        public static string PartTwo(string input)
        {
            return input;
        }
    }
}
