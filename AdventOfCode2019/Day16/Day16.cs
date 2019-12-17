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
            var result = CalculateEFT(ints, phases);

            int firstEight = 0;
            for (int i = 7; i >= 0; i--)
            {
                firstEight += result[7 - i] * (int)Math.Pow(10, i);
            }
            return firstEight;
        }

        private static int[] CalculateEFT(int[] ints, int phases)
        {
            int[] saveInts = new int[ints.Length];
            int[] basePattern = new int[] { 1, 0, -1, 0 };

            for (int phase = 0; phase < phases; phase++)
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
            return ints;
        }

        public static int PartTwo(string filename, long multiplier)
        {
            int[] ints = filename.ReadAll().Select(c => (int)(c - 48)).ToArray();
            int[] big = new int[ints.Length * multiplier];
            for(long m = 0; m < multiplier; m++)
            {
                ints.CopyTo(big, m * ints.Length);
            }

            int offset = 0;
            for (int i = 6; i >= 0; i--)
            {
                offset += ints[6 - i] * (int)Math.Pow(10, i);
            }

            var result = CalculateEFT(big, 100);

            int firstEight = 0;
            for (int i = 7; i >= 0; i--)
            {
                firstEight += result[(offset + 7 - i) % result.Length] * (int)Math.Pow(10, i);
            }
            return firstEight;
        }

        public static int LastDigit(int num) =>
            Math.Abs(num) % 10;
    }
}
