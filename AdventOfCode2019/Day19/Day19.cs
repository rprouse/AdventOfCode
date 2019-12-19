using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day19
    {
        public static long PartOne(string filename)
        {
            long[] program = filename.SplitLongs();
            int count = 0;
            for (int y = 0; y < 50; y++)
            {
                for (int x = 0; x < 50; x++)
                {
                    var drone = new TractorDrone(program, x, y);
                    if (drone.RunProgram() == 1)
                        count++;
                }
            }
            return count;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }

    public class TractorDrone : EventDrivenIntcodeComputer
    {
        public static int Count { get; set; } = 0;

        public TractorDrone(long[] program, int x, int y) : base(program)
        {
            Input.Enqueue(x);
            Input.Enqueue(y);
        }
    }
}
