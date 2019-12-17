using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public static class Day11
    {
        public static int PartOne(string filename) =>
            PaintHull(filename, 0);

        public static int PartTwo(string filename) =>
            PaintHull(filename, 1);

        private static int PaintHull(string filename, int initialColor)
        {
            long[] program = filename.SplitLongs();
            var robot = new HullPaintingRobot(program, initialColor);
            robot.RunProgram();

            string paintJob = robot.ToString();
            Console.WriteLine(paintJob);

            return robot.PanelsPainted;
        }
    }
}
