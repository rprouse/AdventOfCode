using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode.Core;
using AdventOfCode.Core.Routing;

namespace AdventOfCode2021;

public static class Day15
{
    public static int PartOne(string filename)
    {
        int[,] map = ParseMap(filename);
        //var algorithm = new UniformCostSearch(map);
        var algorithm = new Dijkstra(map);
        return algorithm.ShortestDistance(new Point(0, 0), new Point(map.GetLength(0) - 1, map.GetLength(1) - 1));
    }

    public static int PartTwo(string filename)
    {
        int[,] map = ParseMap(filename);
        map = MultiplyMapByFive(map);
        //var algorithm = new UniformCostSearch(map);
        var algorithm = new Dijkstra(map);
        return algorithm.ShortestDistance(new Point(0, 0), new Point(map.GetLength(0) - 1, map.GetLength(1) - 1));
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
                bigMap[x, y] = (map[x % xLen, y % yLen] + i - 1) % 9 + 1;
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
}
