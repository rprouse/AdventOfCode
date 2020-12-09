using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day09
    {
        public static long PartOne(string filename, int preamble)
        {
            long[] lines = filename.GetLongs();
            return FirstNotMatchingRule(lines, preamble);
        }

        public static int PartTwo(string filename)
        {
            long[] lines = filename.GetLongs();
            return 0;
        }

        public static long FirstNotMatchingRule(long[] numbers, int preamble)
        {
            for (int i = preamble; i < numbers.Length; i++)
            {
                if (!SearchPreviousForSummingPair(numbers, preamble, i))
                    return numbers[i];
            }
            return 0;
        }

        private static bool SearchPreviousForSummingPair(long[] numbers, int preamble, int i)
        {
            for (int s = i - preamble; s < i - 1; s++)
            {
                for (int e = s + 1; e < i; e++)
                {
                    if (numbers[i] == numbers[s] + numbers[e])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
