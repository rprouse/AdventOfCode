using System.Threading.Tasks;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day09
    {
        public static async Task<long> PartOne(string filename)
        {
            long[] program = filename.SplitLongs();
            return await RunProgram(program, new long[] { 1 });
        }

        public static async Task<long> PartTwo(string filename)
        {
            long[] program = filename.SplitLongs();
            return await RunProgram(program, new long[] { 2 });
        }

        public static async Task<long> RunProgram(long[] program, long[] input)
        {
            var computer = new IntcodeComputer(program, input);
            return await computer.RunProgram();
        }
    }
}
