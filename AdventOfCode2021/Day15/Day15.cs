using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Drawing;

namespace AdventOfCode2021;

public static class Day15
{
    public static int PartOne(string filename)
    {
        int[,] map = ParseMap(filename);
        return Dijkstra(map, new Point(0, 0), new Point(map.GetLength(0) - 1, map.GetLength(1) - 1));
    }

    public static int PartTwo(string filename)
    {
        int[,] map = ParseMap(filename);
        map = MultiplyMapByFive(map);
        return Dijkstra(map, new Point(0, 0), new Point(map.GetLength(0) - 1, map.GetLength(1) - 1));
    }

    internal static int[,] MultiplyMapByFive(int[,] map)
    {
        int xLen = map.GetLength(0);
        int yLen = map.GetLength(1);
        int[,] bigMap = new int[xLen * 5, yLen * 5];
        for (int y = 0; y < yLen * 5; y++)
        {
            for (int x = 0; x < xLen * 5; x++)
            {
                int i = x / xLen * 5 + y / yLen * 5;
                bigMap[x, y] = (map[x%xLen, y%yLen] + i - 1) % 9 + 1;
            }
        }
        return bigMap;
    }

    internal static int[,] ParseMap(string filename)
    {
        string[] lines = filename.ReadAllLines();
        int[,] map = new int[lines[0].Length, lines.Length];
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[0].Length; x++)
            {
                map[x, y] = lines[y][x] - '0';
            }
        }
        return map;
    }

    // Returns the shortest distance to the destination
    // https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Pseudocode
    internal static int Dijkstra(int[,] graph, Point start, Point end)
    {
        List<Point> queue = new List<Point>();
        Dictionary<Point, int> dist = new Dictionary<Point, int>();
        Dictionary<Point, Point> prev = new Dictionary<Point, Point>();

        for (int y = 0; y < graph.GetLength(1); y++)
        {
            for (int x = 0; x < graph.GetLength(0); x++)
            {
                Point p = new Point(x, y);
                dist[p] = int.MaxValue;
                queue.Add(p);
            }
        }
        dist[start] = 0;

        while (queue.Count > 0)
        {
            int min = queue.Min(p => dist[p]);
            Point u = queue.First(p => dist[p] == min);

            queue.Remove(u);

            // If u is the target, return the distance to it
            if (u == end)
                return dist[prev[u]] + graph[end.X, end.Y];

            // foreach neighbor still in queue
            foreach (Point v in Neighbors(u).Where(p => queue.Contains(p)))
            {
                var alt = dist[u] + graph[v.X, v.Y];
                if (alt < dist[v])
                {
                    dist[v] = alt;
                    prev[v] = u;
                }
            }

        }
        return 0;
    }

    internal static IEnumerable<Point> Neighbors(Point p)
    {
        yield return new Point(p.X + 1, p.Y);
        yield return new Point(p.X - 1, p.Y);
        yield return new Point(p.X, p.Y - 1);
        yield return new Point(p.X, p.Y + 1);
    }
}
