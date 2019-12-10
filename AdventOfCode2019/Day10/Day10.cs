using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day10
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            int w = lines[0].Length;
            int h = lines.Length;

            var canSee = new Dictionary<string, int>();

            for (int y1 = 0; y1 < h; y1++)
            {
                for (int x1 = 0; x1 < w; x1++)
                {
                    if (lines[y1][x1] == '.')
                        continue;

                    int count = 0;
                    var angles = new HashSet<double>();
                    for (int y2 = 0; y2 < h; y2++)
                    {
                        for (int x2 = 0; x2 < w; x2++)
                        {
                            if (lines[y2][x2] == '.')
                                continue;

                            if (x1 == x2 && y1 == y2)
                                continue;

                            double angle = AngleBetween(x1, y1, x2, y2);
                            if(!angles.Contains(angle))
                            {
                                count++;
                                angles.Add(angle);
                            }
                        }
                    }

                    string key = $"{x1},{y1}";
                    canSee[key] = count;
                }
            }
            return canSee.Values.Max();
        }

        public static double AngleBetween(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 && y1 == y2)
                throw new ArgumentException("First point cannot be the same as the second point");

            return Math.Atan2(x1 - x2, y1 - y2);
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
