using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Drawing;

namespace AdventOfCode2021;

public static class Day09
{
    public static int PartOne(string filename)
    {
        var map = GetMap(filename);
        var lowPoints = GetLowPoints(map);
        return lowPoints.Sum(p => map[p.Y][p.X] + 1);
    }

    private static int[][] GetMap(string filename)
    {
        return filename.ReadAllLines()
            .Select(line => line.Select(c => c.ToString().ToInt()).ToArray())
            .ToArray();
    }

    private static IList<Point> GetLowPoints(int[][] map)
    {
        var lowPoints = new List<Point>();
        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                if ((x == 0 || map[y][x] < map[y][x - 1]) &&
                    (y == 0 || map[y][x] < map[y - 1][x]) &&
                    (x == map[y].Length - 1 || map[y][x] < map[y][x + 1]) &&
                    (y == map.Length - 1 || map[y][x] < map[y + 1][x]))
                {
                    lowPoints.Add(new Point(x, y));
                }
            }
        }
        return lowPoints;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
