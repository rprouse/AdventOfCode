using System;
using System.Text;
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

    public class HullPaintingRobot : EventDrivenIntcodeComputer
    {
        const int SIZE = 150;
        int xDir = 0;
        int yDir = -1;
        int x = SIZE / 2;
        int y = SIZE / 2;
        int[,] hull = new int[SIZE, SIZE];
        bool[] painted = new bool[SIZE * SIZE];

        long color;
        long dir;
        bool gotColor;

        public HullPaintingRobot(long[] program, int initialColor) : base(program)
        {
            hull[x, y] = initialColor;
            InputNeeded += HullPaintingRobot_InputNeeded;
            OutputAvailable += HullPaintingRobot_OutputAvailable;
        }

        public int PanelsPainted =>
            painted.Count(b => b);

        private void HullPaintingRobot_InputNeeded(object sender, EventArgs e)
        {
            Input.Enqueue(hull[x, y]);
        }

        private void HullPaintingRobot_OutputAvailable(object sender, EventArgs e)
        {
            if (gotColor)
            {
                dir = Output.Dequeue();

                painted[x * SIZE + y] = true;
                hull[x, y] = (int)color;

                if (dir == 0)
                    TurnLeft();
                else
                    TurnRight();

                x += xDir;
                y += yDir;

                gotColor = false;
            }
            else
            {
                color = Output.Dequeue();
                gotColor = true;
            }
        }

        void TurnLeft()
        {
            if (yDir == -1)
            {
                yDir = 0;
                xDir = -1;
            }
            else if (yDir == 1)
            {
                yDir = 0;
                xDir = 1;
            }
            else if (xDir == -1)
            {
                yDir = 1;
                xDir = 0;
            }
            else if (xDir == 1)
            {
                yDir = -1;
                xDir = 0;
            }
        }

        void TurnRight()
        {
            if (yDir == -1)
            {
                yDir = 0;
                xDir = 1;
            }
            else if (yDir == 1)
            {
                yDir = 0;
                xDir = -1;
            }
            else if (xDir == -1)
            {
                yDir = -1;
                xDir = 0;
            }
            else if (xDir == 1)
            {
                yDir = 1;
                xDir = 0;
            }
        }

        public override string ToString()
        {
            var b = new StringBuilder(SIZE * SIZE);
            for (int y = 0; y < SIZE; y++)
            {
                for (int x = 0; x < SIZE; x++)
                {
                    b.Append(hull[x, y] == 0 ? '░' : '█');
                }
                b.AppendLine();
            }
            return b.ToString();
        }
    }
}
