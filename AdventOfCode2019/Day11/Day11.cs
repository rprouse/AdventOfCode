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
        const int SIZE = 150;
        static int xDir;
        static int yDir;

        public static async Task<int> PartOne(string filename)
        {
            long[] program = filename.SplitLongs();
            var computer = new IntcodeComputer(program);

            int x = SIZE / 2;
            int y = SIZE / 2;
            xDir = 0;
            yDir = -1;
            int[,] hull = new int[SIZE, SIZE];
            bool[] painted = new bool[SIZE * SIZE];

            Task task = Task.Run(async () => await computer.RunProgram());

            hull[x, y] = 1;
            while (!task.IsCompleted)
            {
                computer.Input.Enqueue(hull[x, y]);

                long color = await computer.GetOutput();
                if (task.IsCompleted)
                    break;
                long dir = await computer.GetOutput();
                if (task.IsCompleted)
                    break;

                painted[x * SIZE + y] = true;
                hull[x, y] = (int)color;

                if (dir == 0)
                    TurnLeft();
                else
                    TurnRight();

                x += xDir;
                y += yDir;
            }

            string paintJob = ShowHull(hull);
            Console.WriteLine(paintJob);

            return painted.Count(b => b == true);
        }

        public static string ShowHull(int[,] hull)
        {
            var b = new StringBuilder(SIZE * SIZE);
            for(int y = 0; y < SIZE; y++)
            {
                for(int x = 0; x < SIZE; x++)
                {
                    b.Append(hull[x, y] == 0 ? '░' : '█');
                }
                b.AppendLine();
            }
            return b.ToString();
        }

        static void TurnLeft()
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

        static void TurnRight()
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
    }
}
