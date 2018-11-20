using System;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public class Day01
    {
        int x = 0;
        int y = 0;
        int xDir = -1;
        int yDir = 0;
        
        public int Walk(string walk)
        {
            foreach (var step in walk.Split(',').Select(s => s.Trim()))
            {
                char dir = step[0];
                if (!int.TryParse(step.Substring(1), out int d))
                    continue;

                if(xDir == -1)
                {
                    xDir = 0;
                    if (dir == 'R')
                        yDir = -1;
                    else if (dir == 'L')
                        yDir = 1;
                }
                else if(xDir == 1)
                {
                    xDir = 0;
                    if (dir == 'R')
                        yDir = 1;
                    else if (dir == 'L')
                        yDir = -1;

                }
                else if(yDir == -1)
                {
                    yDir = 0;
                    if (dir == 'R')
                        xDir = 1;
                    else if (dir == 'L')
                        xDir = -1;
                }
                else if(yDir == 1)
                {
                    yDir = 0;
                    if (dir == 'R')
                        xDir = -1;
                    else if (dir == 'L')
                        xDir = 1;
                }

                x += xDir * d;
                y += yDir * d;
            }
            return Math.Abs(x) + Math.Abs(y);
        }

        public static int PartOne(string theWalk)
        {
            var day = new Day01();
            return day.Walk(theWalk);
        }

        public static int PartTwo(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            return 0;
        }
    }
}
