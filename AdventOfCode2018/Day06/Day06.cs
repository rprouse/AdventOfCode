using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day06
    {
        public static int PartOne(string filename)
        {
            (int, int)[] coords = GetCoordinates(filename);
            int maxX = coords.Select(c => c.Item1).Max() + 1;
            int maxY = coords.Select(c => c.Item2).Max() + 1;
            int[,] grid = new int[maxX, maxY];
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    grid[x, y] = ClosestTo(coords, x, y);
                }
            }

            // Zero out everything from the edges
            var infinite = new List<int>();
            for(int x = 0; x < maxX; x++)
            {
                if (grid[x, 0] != -1) infinite.Add(grid[x, 0]);
                if (grid[x, maxY-1] != -1) infinite.Add(grid[x, maxY-1]);
            }
            for (int y = 0; y < maxY; y++)
            {
                if (grid[0, y] != -1) infinite.Add(grid[0, y]);
                if (grid[maxX-1, y] != -1) infinite.Add(grid[maxX-1, y]);
            }
            infinite = infinite.Distinct().ToList();
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    if (infinite.Any(i => i == grid[x, y]))
                        grid[x, y] = -1;
                }
            }

            // Now count the number of each that is left
            var ga = grid.Cast<int>().ToArray();
            int[] distinct = ga.Distinct().Where(i => i != -1).ToArray();
            return distinct.Select(d => ga.Count(i => i == d)).Max();
        }

        public static int PartTwo(string filename, int lessThan)
        {
            (int, int)[] coords = GetCoordinates(filename);
            int maxX = coords.Select(c => c.Item1).Max() + 1;
            int maxY = coords.Select(c => c.Item2).Max() + 1;
            int[,] grid = new int[maxX, maxY];
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    foreach(var coord in coords)
                        grid[x, y] += Distance(coord.Item1, coord.Item2, x, y);
                }
            }

            // Now count the number of each that is left
            var ga = grid.Cast<int>().ToArray();
            return ga.Count(i => i < lessThan);
        }

        public static (int, int)[] GetCoordinates(string filename) =>
            filename.ReadAllLines()
                .Select(l => Parse(l))
                .ToArray();

        public static (int, int) Parse(string line)
        {
            var parts = line.Split(',');
            return (parts[0].ToInt(), parts[1].ToInt());
        }

        public static int Distance(int x1, int y1, int x2, int y2) =>
            Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

        public static int ClosestTo((int, int)[] coords, int x, int y)
        {
            int[] distances = coords.Select(c => Distance(c.Item1, c.Item2, x, y)).ToArray();
            int min = distances.Min();
            int i1 = Array.FindIndex(distances, i => i == min);
            int i2 = Array.FindLastIndex(distances, i => i == min);
            return i1 == i2 ? i1 : -1;
        }
    }
}
