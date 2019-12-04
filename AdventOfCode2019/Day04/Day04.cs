using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day04
    {
        public static int PartOne(int start, int end)
        {
            int count = 0;
            for(int pass = start; pass <= end; pass++)
            {
                if (IsValidPassword(pass)) count++;
            }
            return count;
        }

        public static bool IsValidPassword(int n)
        {
            bool twoSame = false;

            for(int i = 0; i < 5; i++)
            {
                int a = DigitAt(n, i);
                int b = DigitAt(n, i + 1);

                if (a > b) return false;
                if (a == b) twoSame = true;
            }
            return twoSame;
        }

        public static int PartTwo(int start, int end)
        {
            int count = 0;
            for (int pass = start; pass <= end; pass++)
            {
                if (IsValidPassword2(pass)) count++;
            }
            return count;
        }

        public static bool IsValidPassword2(int n)
        {
            bool twoSameWithoutDup = false;

            for (int i = 0; i < 5; i++)
            {
                int a = DigitAt(n, i);
                int b = DigitAt(n, i + 1);

                if (a > b) return false;
                if (a == b)
                {
                    bool foundDup = false;
                    for (int j = 0; j < 6; j++)
                    {
                        if (j == i || j == i + 1)
                            continue;

                        int c = DigitAt(n, j);
                        if(a == c)
                        {
                            foundDup = true;
                            break;
                        }
                    }
                    if(!foundDup) twoSameWithoutDup = true;
                }
            }
            return twoSameWithoutDup;
        }

        public static int DigitAt(int pass, int d)
        {
            for (int i = 0; i < 5 - d; i++)
                pass = pass / 10;

            return pass % 10;
        }

        public static int PartTwo()
        {
            return 0;
        }
    }
}
