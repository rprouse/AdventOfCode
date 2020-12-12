using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day12
    {
        public static int PartOne(string filename)
        {
            int x = 0;
            int y = 0;
            var dir = new Direction();
            string[] lines = filename.ReadAllLines();
            foreach(var line in filename.ReadAllLines())
            {
                char action = line[0];
                int value = line[1..].ToInt();
                switch(action)
                {
                    case 'N':
                        y -= value;
                        break;
                    case 'S':
                        y += value;
                        break;
                    case 'E':
                        x += value;
                        break;
                    case 'W':
                        x -= value;
                        break;
                    case 'L':
                        dir.TurnLeft(value);
                        break;
                    case 'R':
                        dir.TurnRight(value);
                        break;
                    case 'F':
                        x += dir.X * value;
                        y += dir.Y * value;
                        break;
                }
            }
            return Math.Abs(x) + Math.Abs(y);
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }

    public class Direction
    {
        public int X { get; set; } = 1;
        public int Y { get; set; } = 0;

        public override string ToString() => $"{X},{Y}";

        public void TurnLeft(int degrees)
        {
            TurnLeft();
            if (degrees >= 180)
                TurnLeft();
            if (degrees == 270)
                TurnLeft();
        }

        public void TurnLeft()
        {
            if (Y == -1)
            {
                Y = 0;
                X = -1;
            }
            else if (Y == 1)
            {
                Y = 0;
                X = 1;
            }
            else if (X == -1)
            {
                Y = 1;
                X = 0;
            }
            else if (X == 1)
            {
                Y = -1;
                X = 0;
            }
        }

        public void TurnRight(int degrees)
        {
            TurnRight();
            if (degrees >= 180)
                TurnRight();
            if (degrees == 270)
                TurnRight();
        }

        public void TurnRight()
        {
            if (Y == -1)
            {
                Y = 0;
                X = 1;
            }
            else if (Y == 1)
            {
                Y = 0;
                X = -1;
            }
            else if (X == -1)
            {
                Y = -1;
                X = 0;
            }
            else if (X == 1)
            {
                Y = 1;
                X = 0;
            }
        }
    }
}
