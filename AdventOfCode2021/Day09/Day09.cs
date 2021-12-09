using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day09
{
    public static int PartOne(string filename)
    {
        var map = GetMap(filename);
        var lowPoints = GetLowPoints(map);
        return lowPoints.Sum(p => map[p.Y][p.X] + 1);
    }

    public static int PartTwo(string filename)
    {
        var map = GetMap(filename);
        var lowPoints = GetLowPoints(map);
        var basinSizes = lowPoints
            .Select(p => BasinSize(map, p))
            .OrderByDescending(i => i)
            .Take(3);

        int result = 1;
        foreach (var size in basinSizes)
            result *= size;
        return result;
    }

    internal static int[][] GetMap(string filename)
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

    internal static int BasinSize(int[][] map, Point lowPoint)
    {
        var visited = new List<Point>();
        visited.Add(lowPoint);
        Walk(map, visited, lowPoint);
        return visited.Count;
    }

    private static void Walk(int[][] map, List<Point> visited, Point point)
    {
        var neighbors = new List<Point>();

        var left = new Point(point.X - 1, point.Y);
        if (left.X >= 0 && map[left.Y][left.X] != 9 && !visited.Contains(left))
        {
            neighbors.Add(left);
            visited.Add(left);
        }

        var right = new Point(point.X + 1, point.Y);
        if (right.X < map[right.Y].Length && map[right.Y][right.X] != 9 && !visited.Contains(right))
        {
            neighbors.Add(right);
            visited.Add(right);
        }

        var up = new Point(point.X, point.Y - 1);
        if (up.Y >= 0 && map[up.Y][up.X] != 9 && !visited.Contains(up))
        {
            neighbors.Add(up);
            visited.Add(up);
        }

        var down = new Point(point.X, point.Y + 1);
        if (down.Y < map.Length && map[down.Y][down.X] != 9 && !visited.Contains(down))
        {
            neighbors.Add(down);
            visited.Add(down);
        }

        foreach (var neighbor in neighbors)
        {
            Walk(map, visited, neighbor);
        }
    }
}
