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
            int[] codes = filename.SplitInts();
            int max = 0;

            for (int a = 0; a < 5; a++)
                for (int b = 0; b < 5; b++)
                    for (int c = 0; c < 5; c++)
                        for (int d = 0; d < 5; d++)
                            for (int e = 0; e < 5; e++)
                            {
                                if (a != b && a != c && a != d && a != e &&
                                    b != c && b != d && b != e &&
                                    c != d && c != e &&
                                    d != e)
                                {
                                    int result = RunProgram(codes, new int[] { a, b, c, d, e });
                                    if (result > max)
                                        max = result;
                                }
                            }

            return max;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        public static int RunProgram(int[] program, int[] sequence)
        {
            int ret = 0;
            for (int i = 0; i < 5; i++)
            {
                int[] input = new int[] { sequence[i], ret };
                var computer = new IntcodeComputer(program, input);
                ret = computer.RunProgram();
            }
            return ret;
        }
    }
}
