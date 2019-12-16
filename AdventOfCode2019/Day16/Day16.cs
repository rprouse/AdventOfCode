using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day16
    {
        public static int PartOne(string filename, int phases)
        {
            int[] ints = filename.ReadAll().Select(c => (int)(c - 48)).ToArray();
            int[] saveInts = new int[ints.Length];
            int[] basePattern = new int[] { 1, 0, -1, 0 };

            for(int phase = 0; phase < phases; phase++)
            {
                ints.CopyTo(saveInts, 0);
                for (int n = 0; n < ints.Length; n++)
                {
                    int i = n;
                    long newValue = 0;
                    string debug = string.Empty;
                    while (i < ints.Length)
                    {
                        for (int j = 0; j < basePattern.Length; j++)
                        {
                            for (int k = 0; k <= n && i < ints.Length; k++)
                            {
                                debug = $"N:{n}, I:{i}, RI: {j}, R:{basePattern[j]}, A:{saveInts[i] * basePattern[j]}";
                                newValue += saveInts[i] * basePattern[j];
                                i++;
                            }
                        }
                    }
                    ints[n] = LastDigit((int)newValue);
                }
            }

            int firstEight = 0;
            for(int i = 7; i >= 0; i--)
            {
                firstEight += ints[7 - i] * (int)Math.Pow(10, i);
            }
            return firstEight;
        }

        public static int PartTwo(string filename)
        {
            int[] ints = filename.SplitInts();
            return 0;
        }

        public static int LastDigit(int num) =>
            Math.Abs(num) % 10;
    }
}
