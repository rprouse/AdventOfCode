using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day11
{
    public static class Day11
    {
        public static int PartOne(string[] steps)
        {
            int x = 0;
            int y = 0;
            foreach(var step in steps)
            {
                switch(step)
                {
                    case "n":
                        y++;
                        break;
                    case "ne":
                        x++;
                        y++;
                        break;
                    case "nw":
                        x--;
                        break;
                    case "s":
                        y--;
                        break;
                    case "se":
                        x++;
                        break;
                    case "sw":
                        x--;
                        y--;
                        break;
                }
            }
            return Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Abs((x - y) * -1));
        }

        public static int PartTwo(string[] steps)
        {
            int x = 0;
            int y = 0;
            int max = 0;
            foreach (var step in steps)
            {
                switch (step)
                {
                    case "n":
                        y++;
                        break;
                    case "ne":
                        x++;
                        y++;
                        break;
                    case "nw":
                        x--;
                        break;
                    case "s":
                        y--;
                        break;
                    case "se":
                        x++;
                        break;
                    case "sw":
                        x--;
                        y--;
                        break;
                }
                int d = Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Abs((x - y) * -1));
                if (d > max) max = d;
            }
            return max;

        }
    }
}
