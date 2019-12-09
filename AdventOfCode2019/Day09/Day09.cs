using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public static class Day09
    {
        public static async Task<long> PartOne(string filename)
        {
            long[] program = filename.SplitLongs();
            return await RunProgram(program, new long[] { 1 });
        }

        public static int PartTwo(string filename)
        {
            long[] program = filename.SplitLongs();
            return 0;
        }

        public static async Task<long> RunProgram(long[] program, long[] input)
        {
            var computer = new IntcodeComputer(program, input);
            return await computer.RunProgram();
        }
    }
}
