using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day10
    {
        public static int PartOne(string filename)
        {
            int[] adp = filename.GetInts();
            Array.Sort(adp);
            int one = 0;
            int two = 0;
            int thr = 1;
            for(int i = -1; i < adp.Length - 1; i++)
            {
                int diff = i == -1 ? adp[0] : adp[i + 1] - adp[i];
                switch (diff)
                {
                    case 1:
                        one++;
                        break;
                    case 2:
                        two++;
                        break;
                    case 3:
                        thr++;
                        break;
                }
            }
            return one * thr;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
