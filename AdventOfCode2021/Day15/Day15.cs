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
        //return Dijkstra(map, new Point(0, 0), new Point(map.GetLength(0) - 1, map.GetLength(1) - 1));
        return UniformCostSearch(map, new Point(0, 0), new Point(map.GetLength(0) - 1, map.GetLength(1) - 1));
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
                int i = x / xLen + y / yLen;
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

    // https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Practical_optimizations_and_infinite_graphs
    internal static int UniformCostSearch(int[,] graph, Point start, Point end)
    {
        int width = graph.GetLength(0);
        int height = graph.GetLength(1);
        Node node = new Node { Point = start, Cost = 0 };
        var frontier = new PriorityQueue<Node, int>();
        frontier.Enqueue(node, 0);
        bool[,] explored = new bool[graph.GetLength(0), graph.GetLength(1)];

        while(true)
        {
            if (frontier.Count == 0)
                throw new Exception("Failed to find UCS route");

            node = frontier.Dequeue();
            if (node.Point == end)
            {
                return node.Cost;
            }
            explored[node.Point.X, node.Point.Y] = true;
            foreach(var neighbor in Neighbors(node.Point, width, height))
            {
                if(!explored[neighbor.X, neighbor.Y])
                {
                    var neighborNode = new Node { Point = neighbor, Cost = graph[neighbor.X,neighbor.Y] + node.Cost };
                    frontier.Enqueue(neighborNode, neighborNode.Cost);
                }
            }
        }
    }

    public struct Node
    {
        public Point Point { get; init; }
        public int Cost { get; init; }
    }

    internal static bool InGraph(Point point, int[,] map) =>
        point.X >= 0 && 
        point.Y >= 0 &&
        point.X < map.GetLength(0) &&
        point.Y < map.GetLength(1);

    // Returns the shortest distance to the destination
    // https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Pseudocode
    internal static int Dijkstra(int[,] graph, Point start, Point end)
    {
        int width = graph.GetLength(0);
        int height = graph.GetLength(1);
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
            foreach (Point v in Neighbors(u, width, height).Where(p => queue.Contains(p)))
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

    internal static IEnumerable<Point> Neighbors(Point p, int width, int height)
    {
        if (p.X < width ) yield return new Point(p.X + 1, p.Y);
        if (p.X > 0 ) yield return new Point(p.X - 1, p.Y);
        if (p.Y > 0 )yield return new Point(p.X, p.Y - 1);
        if (p.Y < height ) yield return new Point(p.X, p.Y + 1);
    }
}
