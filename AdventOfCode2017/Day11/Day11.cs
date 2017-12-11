using System;

namespace AdventOfCode2017.Day11
{
    public static class Day11
    {
        public static int PartOne(string[] steps)
        {
            int x = 0;
            int y = 0;
            foreach (var step in steps)
            {
                Step(ref x, ref y, step);
            }
            return CalculateDistance(x, y);
        }

        public static int PartTwo(string[] steps)
        {
            int x = 0;
            int y = 0;
            int max = 0;
            foreach (var step in steps)
            {
                Step(ref x, ref y, step);
                int d = CalculateDistance(x, y);
                if (d > max) max = d;
            }
            return max;
        }

        private static void Step(ref int x, ref int y, string step)
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
        }

        private static int CalculateDistance(int x, int y)
        {
            return Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Abs((x - y) * -1));
        }
    }
}
