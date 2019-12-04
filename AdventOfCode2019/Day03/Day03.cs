using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day03
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return ClosestJunction(lines[0], lines[1]);
        }

        public static int ClosestJunction(string wire1, string wire2)
        {
            Dictionary<string, int> path1 = FollowWire(wire1);
            Dictionary<string, int> path2 = FollowWire(wire2);
            int minDist = int.MaxValue;

            foreach (var one in path1.Keys)
            {
                if (path2.ContainsKey(one))
                {
                    string[] split = one.Split(',');
                    int d = Distance(split[0].ToInt(), split[1].ToInt(), 0, 0);
                    if (d < minDist)
                        minDist = d;
                }
            }
            return minDist;
        }

        static int Distance(int x, int y, int x1, int y1) =>
            Math.Abs(x - x1) + Math.Abs(y - y1);

        public static Dictionary<string, int> FollowWire(string wire)
        {
            var list = new Dictionary<string, int>();
            int x = 0;
            int y = 0;
            int i = 0;

            string[] steps = wire.Split(",", StringSplitOptions.RemoveEmptyEntries);

            foreach (string step in steps)
            {
                char dir = step[0];
                int dist = step.Substring(1).ToInt();
                switch (dir)
                {
                    case 'U':
                        for (int c = 0; c < dist; c++)
                        {
                            list[$"{x},{y++}"] = i++;
                        }
                        break;
                    case 'D':
                        for (int c = 0; c < dist; c++)
                        {
                            list[$"{x},{y--}"] = i++;
                        }
                        break;
                    case 'L':
                        for (int c = 0; c < dist; c++)
                        {
                            list[$"{x--},{y}"] = i++;
                        }
                        break;
                    case 'R':
                        for (int c = 0; c < dist; c++)
                        {
                            list[$"{x++},{y}"] = i++;
                        }
                        break;
                }
            }
            list[$"{x},{y}"] = i++;
            list.Remove("0,0");
            return list;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
