using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2017
{
    public static class Day5
    {
        public static int CountJumps(this int[] instuctions)
        {
            int jumps = 0;
            int pointer = 0;
            while(pointer >= 0 && pointer < instuctions.Length)
            {
                int jump = instuctions[pointer];
                instuctions[pointer]++;
                pointer += jump;
                jumps++;
            }
            return jumps;
        }
    }
}
