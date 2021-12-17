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
        return 0;
    }

    public static int PartTwo(string filename)
    {
        int[,] map = ParseMap(filename);
        return 0;
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

    internal static int Dijkstra(int[,] graph, Point start, Point end)
    {
        List<Point> queue = new List<Point>();
        Dictionary<Point, int> dist = new Dictionary<Point, int>();
        Point[,] prev = new Point[graph.GetLength(0), graph.GetLength(1)];

        for (int y = 0; y < graph.GetLength(1); y++)
        {
            for(int x = 0; x <= graph.GetLength(0); x++)
            {
                Point p = new Point(x, y);
                dist[p] = int.MaxValue;
                queue.Add(p);
            }
        }
        dist[start] = 0;

        while(queue.Count > 0)
        {
            int min = queue.Min(p => dist[p]);
            Point u = queue.First(p => dist[p] == min);

            queue.Remove(u);

            // foreach neighbor still in queue

        }

        return 0;
    }
}
