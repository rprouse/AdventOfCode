using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public class Day01
    {
        List<Point> visited = new List<Point> { new Point(0, 0) };
        Point point = new Point(0, 0);
        int xDir = -1;
        int yDir = 0;
        
        public int Walk(string walk)
        {
            foreach (var step in walk.Split(',').Select(s => s.Trim()))
            {
                char dir = step[0];
                if (!int.TryParse(step.Substring(1), out int d))
                    continue;

                Turn(dir);

                point.X += xDir * d;
                point.Y += yDir * d;
            }
            return Math.Abs(point.X) + Math.Abs(point.Y);
        }

        public int FullWalk(string walk)
        {
            foreach (var step in walk.Split(',').Select(s => s.Trim()))
            {
                char dir = step[0];
                if (!int.TryParse(step.Substring(1), out int d))
                    continue;

                Turn(dir);

                for (int i = 0; i < d; i++)
                {
                    point.X += xDir;
                    point.Y += yDir;

                    if (visited.Any(p => p.X == point.X && p.Y == point.Y))
                        return Math.Abs(point.X) + Math.Abs(point.Y);

                    visited.Add(point);
                }
            }
            return 0;
        }

        private void Turn(char dir)
        {
            if (xDir == -1)
            {
                xDir = 0;
                if (dir == 'R')
                    yDir = -1;
                else if (dir == 'L')
                    yDir = 1;
            }
            else if (xDir == 1)
            {
                xDir = 0;
                if (dir == 'R')
                    yDir = 1;
                else if (dir == 'L')
                    yDir = -1;

            }
            else if (yDir == -1)
            {
                yDir = 0;
                if (dir == 'R')
                    xDir = 1;
                else if (dir == 'L')
                    xDir = -1;
            }
            else if (yDir == 1)
            {
                yDir = 0;
                if (dir == 'R')
                    xDir = -1;
                else if (dir == 'L')
                    xDir = 1;
            }
        }

        public static int PartOne(string theWalk)
        {
            var day = new Day01();
            return day.Walk(theWalk);
        }

        public static int PartTwo(string theWalk)
        {
            var day = new Day01();
            return day.FullWalk(theWalk);
        }
    }
}
