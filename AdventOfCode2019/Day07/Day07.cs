using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day07
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        public static int RunProgram(int[] program, int[] sequence)
        {
            int ret = 0;
            for(int i = 0; i < 5; i++)
            {
                int[] input = new int[] { sequence[i], ret };
                var computer = new IntcodeComputer(program, input);
                ret = computer.RunProgram();
            }
            return ret;
        }
    }
}
