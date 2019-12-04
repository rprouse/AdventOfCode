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
