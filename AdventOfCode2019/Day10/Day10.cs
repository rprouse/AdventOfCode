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
            var map = ConvertMap(filename.ReadAllLines());
            int w = map[0].Length;
            int h = map.Count;
            var canSee = FindHowManyAsteroidsCanBeSeen(map, w, h);
            return canSee.Values.Max();
        }

        public static int PartTwo(string filename)
        {
            var map = ConvertMap(filename.ReadAllLines());
            int w = map[0].Length;
            int h = map.Count;

            // Find the new base
            var canSee = FindHowManyAsteroidsCanBeSeen(map, w, h);
            int max = canSee.Values.Max();
            var newBase = canSee.First(pair => pair.Value == max).Key;
            int bx = newBase.Item1;
            int by = newBase.Item2;

            // Get all the angles to the other asteroids
            var angles = new Dictionary<double, List<Tuple<int, int>>>();
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (map[y][x] == '.')
                        continue;

                    if (x == bx && y == by)
                        continue;

                    double angle = AngleBetween(bx, by, x, y);
                    if (!angles.ContainsKey(angle))
                    {
                        angles.Add(angle, new List<Tuple<int, int>>());
                    }
                    angles[angle].Add(new Tuple<int, int>(x, y));
                }
            }

            // Start blasting!
            int blasted = 0;
            List<double> sorted = angles.Keys.ToList();
            sorted.Sort();
            while(true)
            {
                foreach(double angle in sorted)
                {
                    double minDist = double.MaxValue;
                    Tuple<int, int> closest = null;
                    foreach(var ast in angles[angle])
                    {
                        double dist = Distance(bx, by, ast);
                        if(dist < minDist)
                        {
                            minDist = dist;
                            closest = ast;
                        }
                    }
                    if (closest != null)
                    {
                        blasted++;
                        angles[angle].Remove(closest);

                        if (blasted == 200)
                            return closest.Item1 * 100 + closest.Item2;
                    }
                }
            }
        }

        static double Distance(int x, int y, Tuple<int, int> t) =>
            Math.Sqrt((x - t.Item1) * (x - t.Item1) + (y - t.Item2) * (y - t.Item2));

        private static List<char[]> ConvertMap(string[] lines) =>
            lines.Select(l => l.ToCharArray()).ToList();

        private static Dictionary<Tuple<int, int>, int> FindHowManyAsteroidsCanBeSeen(List<char[]> map, int w, int h)
        {
            var canSee = new Dictionary<Tuple<int, int>, int>();

            for (int y1 = 0; y1 < h; y1++)
            {
                for (int x1 = 0; x1 < w; x1++)
                {
                    if (map[y1][x1] == '.')
                        continue;

                    int count = 0;
                    var angles = new HashSet<double>();
                    for (int y2 = 0; y2 < h; y2++)
                    {
                        for (int x2 = 0; x2 < w; x2++)
                        {
                            if (map[y2][x2] == '.')
                                continue;

                            if (x1 == x2 && y1 == y2)
                                continue;

                            double angle = AngleBetween(x1, y1, x2, y2);
                            if (!angles.Contains(angle))
                            {
                                count++;
                                angles.Add(angle);
                            }
                        }
                    }

                    var key = new Tuple<int, int>(x1, y1);
                    canSee[key] = count;
                }
            }
            return canSee;
        }

        public static double AngleBetween(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 && y1 == y2)
                throw new ArgumentException("First point cannot be the same as the second point");

            return Math.Atan2(x1 - x2, y1 - y2);
        }
    }
}
