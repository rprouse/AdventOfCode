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
                    int max = ints.Length;
                    while (i < max)
                    {
                        for (int j = 0; j < basePattern.Length && i < max; j++)
                        {
                            for (int k = 0; k <= n && i < max; k++)
                            {
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
            short[] vals = filename.ReadAll().Select(c => (short)(c - 48)).ToArray();
            short[] big = new short[vals.Length * multiplier];
            for (long m = 0; m < multiplier; m++)
            {
                vals.CopyTo(big, m * vals.Length);
            }

            int offset = 0;
            for (int i = 6; i >= 0; i--)
            {
                offset += vals[6 - i] * (int)Math.Pow(10, i);
            }

            var result = CalculateEFT2(big, 100, offset);

            int firstEight = 0;
            for (int i = 7; i >= 0; i--)
            {
                firstEight += result[(7 - i) % result.Length] * (int)Math.Pow(10, i);
            }
            return firstEight;
        }

        private static short[] CalculateEFT2(short[] input, int phases, int offset)
        {
            short[] a1 = new short[input.Length - offset];
            short[] a2 = new short[a1.Length];
            short[] swap;
            Array.Copy(input, offset, a1, 0, input.Length - offset);
            a1.CopyTo(a2, 0);
            long newValue;
            int i;

            for (int phase = 0; phase < phases; phase++)
            {
                swap = a1;
                a1 = a2;
                a2 = swap;
                int max = a1.Length + offset;
                for (int n = offset; n < max; n++)
                {
                    i = n;
                    newValue = 0;
                    while (i < max)
                    {
                        newValue += a2[i - offset];
                        i++;
                    }
                    a1[n - offset] = (short)(newValue % 10);
                }
            }
            return a1;
        }

        public static int LastDigit(int num) =>
            Math.Abs(num) % 10;
    }
}
