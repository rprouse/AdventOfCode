using System.Collections.Generic;

namespace AdventOfCode2017
{
    public static class Day17
    {
        public static int PartOne(int skip)
        {
            var pos = 0;
            var buffer = new List<int> { 0 };
            for(int i = 1; i <= 2017; i++)
            {
                pos = ((pos + skip) % i) + 1;
                buffer.Insert(pos, i);
            }
            return buffer[pos+1];
        }

        public static int PartTwo(int skip)
        {
            var pos = 0;
            var one = 1;
            for (int i = 1; i <= 50000000; i++)
            {
                pos = ((pos + skip) % i) + 1;
                if (pos == 1) one = i;
            }
            return one;
        }
    }
}
