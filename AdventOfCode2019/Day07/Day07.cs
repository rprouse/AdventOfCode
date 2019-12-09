using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public static class Day07
    {
        public static async Task<int> PartOne(string filename)
        {
            long[] codes = filename.SplitLongs();
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
                                    int result = await RunProgram(codes, new long[] { a, b, c, d, e });
                                    if (result > max)
                                        max = result;
                                }
                            }

            return max;
        }

        public static async Task<int> RunProgram(long[] program, long[] sequence)
        {
            int ret = 0;
            for (int i = 0; i < 5; i++)
            {
                long[] input = new long[] { sequence[i], ret };
                var computer = new IntcodeComputer(program, input);
                ret = (int)(await computer.RunProgram());
            }
            return ret;
        }

        public static int PartTwo(string filename)
        {
            long[] codes = filename.SplitLongs();
            int max = 0;

            for (int a = 5; a < 10; a++)
                for (int b = 5; b < 10; b++)
                    for (int c = 5; c < 10; c++)
                        for (int d = 5; d < 10; d++)
                            for (int e = 5; e < 10; e++)
                            {
                                if (a != b && a != c && a != d && a != e &&
                                    b != c && b != d && b != e &&
                                    c != d && c != e &&
                                    d != e)
                                {
                                    int result = RunProgramInFeedbackLoop(codes, new long[] { a, b, c, d, e });
                                    if (result > max)
                                        max = result;
                                }
                            }

            return max;
        }

        public static int RunProgramInFeedbackLoop(long[] program, long[] sequence)
        {
            int ret = 0;

            // Create computers
            IntcodeComputer[] computers = new IntcodeComputer[5];

            // Create computers hooking Input/Output together
            for (int i = 0; i < 5; i++)
            {
                computers[i] = new IntcodeComputer(program);
                if (i > 0)
                    computers[i].Input = computers[i - 1].Output;
            }
            computers[0].Input = computers[4].Output;

            // Prime the sequence
            for (int i = 0; i < 5; i++)
                computers[i].Input.Enqueue(sequence[i]);

            // Prime the first computer
            computers[0].Input.Enqueue(0);

            // Run the computers
            List<Task<int>> tasks = new List<Task<int>>();
            foreach (var computer in computers)
            {
                Task<int> result = Task.Run(async () => (int)(await computer.RunProgram()));
                tasks.Add(result);
            }

            // Wait for them to finish
            Task.WaitAll(tasks.ToArray());

            return (int)computers[4].Output.Dequeue();
        }
    }
}
