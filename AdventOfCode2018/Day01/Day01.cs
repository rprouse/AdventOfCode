using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day01
    {
        public static int PartOne(string filename) =>
            filename.GetInts().Sum();

        public static int PartTwo(string filename)
        {
            int[] ints = filename.GetInts();
            var found = new List<int>();
            var freq = 0;
            while(true)
            {
                foreach(int i in ints)
                {
                    freq += i;
                    if (found.Contains(freq))
                        return freq;
                    found.Add(freq);
                }
            }
        }
    }
}
