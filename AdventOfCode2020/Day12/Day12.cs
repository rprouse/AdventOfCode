using System;
using System.Drawing;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    /// <summary>
    /// Note to self, I use screen coordinates for this problem
    /// with X increasing right (East) and Y increasing down (South)
    /// </summary>
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
            var ship = new Point(0, 0);
            var wp = new Waypoint(10, -1);
            string[] lines = filename.ReadAllLines();
            foreach (var line in filename.ReadAllLines())
            {
                char action = line[0];
                int value = line[1..].ToInt();
                switch (action)
                {
                    case 'N':
                        wp.Offset(0, -value);
                        break;
                    case 'S':
                        wp.Offset(0, value);
                        break;
                    case 'E':
                        wp.Offset(value, 0);
                        break;
                    case 'W':
                        wp.Offset(-value, 0);
                        break;
                    case 'L':
                        wp.TurnLeft(value);
                        break;
                    case 'R':
                        wp.TurnRight(value);
                        break;
                    case 'F':
                        ship.Offset(wp.X * value, wp.Y * value);
                        break;
                }
            }
            return Math.Abs(ship.X) + Math.Abs(ship.Y);
        }
    }
}
