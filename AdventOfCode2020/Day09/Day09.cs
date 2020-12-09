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

        public static long PartTwo(string filename, long mismatch)
        {
            long[] lines = filename.GetLongs();
            return FindContigiousSetForMismatch(lines, mismatch);
        }

        static long FirstNotMatchingRule(long[] numbers, int preamble)
        {
            for (int i = preamble; i < numbers.Length; i++)
            {
                if (!SearchPreviousForSummingPair(numbers, preamble, i))
                    return numbers[i];
            }
            return 0;
        }

        static bool SearchPreviousForSummingPair(long[] numbers, int preamble, int i)
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

        static long FindContigiousSetForMismatch(long[] numbers, long mismatch)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                long sum = 0;
                for(int j = i; j < numbers.Length; j++)
                {
                    sum += numbers[j];
                    if (sum == mismatch)
                    {
                        return SumMinMaxOfRange(numbers, i, j);
                    }
                }
            }
            return 0;
        }

        private static long SumMinMaxOfRange(long[] numbers, int i, int j)
        {
            long min = long.MaxValue;
            long max = long.MinValue;
            for (int k = i; k <= j; k++)
            {
                if (numbers[k] < min) min = numbers[k];
                if (numbers[k] > max) max = numbers[k];
            }
            return min + max;
        }
    }
}
