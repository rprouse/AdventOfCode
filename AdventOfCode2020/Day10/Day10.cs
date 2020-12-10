using System;
using System.Collections.Generic;
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

        public static long PartTwo(string filename)
        {
            List<int> adp = filename.GetInts().ToList();
            adp.Add(0);
            adp.Sort();
            adp.Add(adp.Last() + 3);

            long routes = 1;
            List<int> subList = new List<int>();
            int last = 0;
            foreach(var i in adp)
            {
                if (i < last + 3)
                {
                    subList.Add(i);
                }
                else
                {
                    routes *= RoutesToEnd(subList.ToArray(), 0);
                    subList.Clear();
                    subList.Add(i);
                }
                last = i;
            }
            return routes;
        }

        static long RoutesToEnd(int[] adp, int idx)
        {
            if (idx == adp.Length - 1) return 1;
            long routes = 0;
            for (int i = idx + 1; i <= idx + 3 && i < adp.Length; i++)
            {
                int diff = adp[i] - adp[idx];
                if (diff <= 3)
                    routes += RoutesToEnd(adp, i);
            }
            return routes;
        }
    }
}
