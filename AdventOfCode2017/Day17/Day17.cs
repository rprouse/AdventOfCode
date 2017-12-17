using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day17
    {
        public static int PartOne(int skip)
        {
            var buffer = new List<int> { 0 };
            var pos = 0;
            for(int i = 1; i <= 2017; i++)
            {
                pos = (pos + skip) % buffer.Count;
                buffer.Insert(++pos, i);
            }
            return buffer[pos+1];
        }

        public static int PartTwo(int str)
        {
            return 0;
        }
    }
}
