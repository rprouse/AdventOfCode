using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day09
{
    public static int PartOne(string filename)
    {
        var map = filename.ReadAllLines()
            .Select(line => line.Select(c => c.ToString().ToInt()).ToArray())
            .ToArray();

        int risk = 0;
        for(int y = 0; y < map.Length; y++)
        {
            for(int x = 0; x < map[y].Length; x++)
            {
                try
                {
                    if ((x == 0 || map[y][x] < map[y][x - 1]) &&
                       (y == 0 || map[y][x] < map[y - 1][x]) &&
                       (x == map[y].Length - 1 || map[y][x] < map[y][x + 1]) &&
                       (y == map.Length - 1 || map[y][x] < map[y + 1][x]))
                    {
                        risk += map[y][x] + 1;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine($"{x},{y} = {map[y].Length},{map.Length}");
                }
            }
        }
        return risk;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
