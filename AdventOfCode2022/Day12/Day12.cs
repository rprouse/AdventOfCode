using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Drawing;
using AdventOfCode.Core.Routing;

namespace AdventOfCode2022;

public static class Day12
{
    public static int PartOne(string filename)
    {
        var map = new HeightMap(filename);
        return map.Walk();
    }

public static int PartTwo(string filename)
{
    string[] lines = filename.ReadAllLines();
    return 0;
}
}

public class HeightMap
{
    char[,] _map;
    private readonly int _width;
    private readonly int _height;
    Point start;
    Point end;

    public HeightMap(string filename)
    {
        string[] lines = filename.ReadAllLines();
        _width = lines[0].Length;
        _height = lines.Length;
        _map = new char[_width, _height];
        start = new Point(0, 0);
        end = new Point(0, 0);

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                if (lines[y][x] == 'S')
                {
                    start = new Point(x, y);
                    _map[x, y] = 'a';
                }
                else if (lines[y][x] == 'E')
                {
                    end = new Point(x, y);
                    _map[x, y] = 'z';
                }
                else
                {
                    _map[x, y] = lines[y][x];
                }
            }
        }
    }

    /// <summary>
    /// Modified Dijkstra but distances are all one
    /// </summary>
    /// <returns></returns>
    public int Walk()
    {
        var queue = new PriorityQueue<Point, int>();
        var dist = new Dictionary<Point, int>();
        var prev = new Dictionary<Point, Point>();

        queue.Enqueue(start, 0);
        dist[start] = 0;

        while (queue.Count > 0)
        {
            Point u = queue.Dequeue();

            // If u is the target, return the distance to it
            if (u == end)
                return dist[prev[u]] + 1;

            // foreach neighbor still in queue
            foreach (Point v in u.Neighbors(_width, _height)
                .Where(p => _map[p.X, p.Y] == _map[u.X, u.Y] || 
                            _map[p.X, p.Y] == _map[u.X, u.Y] + 1))
            {
                var alt = dist[u] + 1;
                if (!dist.ContainsKey(v) || alt < dist[v])
                {
                    dist[v] = alt;
                    prev[v] = u; // This is wrong marking the previous point with the dist. I'll need to keep a separate list.
                    queue.Enqueue(v, alt);
                }
            }
        }
        return 0;
    }
}