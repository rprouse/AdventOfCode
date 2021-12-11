using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day11
{
    public static int PartOne(string filename)
    {
        int flashes = 0;
        int[][] map = GetMap(filename);
        foreach (var _ in Enumerable.Range(0, 100))
        {
            // Increment all by one
            foreach (var row in map)
            {
                for (int i = 0; i < row.Length; i++)
                    row[i]++;
            }
            // Flash
            bool found = true;
            while (found)
            {
                found = false;
                for (int y = 0; y < map.Length; y++)
                {
                    for (int x = 0; x < map[y].Length; x++)
                    {
                        if (map[y][x] > 9)
                        {
                            found = true;
                            flashes++;
                            map[y][x] = 0;

                            if (y > 0 && map[y - 1][x] != 0) map[y - 1][x]++;
                            if (x > 0 && map[y][x - 1] != 0) map[y][x - 1]++;
                            if (y < 9 && map[y + 1][x] != 0) map[y + 1][x]++;
                            if (x < 9 && map[y][x + 1] != 0) map[y][x + 1]++;

                            if (y > 0 && x > 0 && map[y - 1][x - 1] != 0) map[y - 1][x - 1]++;
                            if (y < 9 && x > 0 && map[y + 1][x - 1] != 0) map[y + 1][x - 1]++;
                            if (y > 0 && x < 9 && map[y - 1][x + 1] != 0) map[y - 1][x + 1]++;
                            if (y < 9 && x < 9 && map[y + 1][x + 1] != 0) map[y + 1][x + 1]++;
                        }
                    }
                }
            }
            //OutputMap(map);
        }
        return flashes;
    }

    static void OutputMap(int[][] map)
    {
        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                Console.Write(map[y][x]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static int PartTwo(string filename)
    {
        int steps = 0;
        int[][] map = GetMap(filename);
        do
        {
            // Increment all by one
            foreach (var row in map)
            {
                for (int i = 0; i < row.Length; i++)
                    row[i]++;
            }
            // Flash
            bool found = true;
            while (found)
            {
                found = false;
                for (int y = 0; y < map.Length; y++)
                {
                    for (int x = 0; x < map[y].Length; x++)
                    {
                        if (map[y][x] > 9)
                        {
                            found = true;
                            map[y][x] = 0;

                            if (y > 0 && map[y - 1][x] != 0) map[y - 1][x]++;
                            if (x > 0 && map[y][x - 1] != 0) map[y][x - 1]++;
                            if (y < 9 && map[y + 1][x] != 0) map[y + 1][x]++;
                            if (x < 9 && map[y][x + 1] != 0) map[y][x + 1]++;

                            if (y > 0 && x > 0 && map[y - 1][x - 1] != 0) map[y - 1][x - 1]++;
                            if (y < 9 && x > 0 && map[y + 1][x - 1] != 0) map[y + 1][x - 1]++;
                            if (y > 0 && x < 9 && map[y - 1][x + 1] != 0) map[y - 1][x + 1]++;
                            if (y < 9 && x < 9 && map[y + 1][x + 1] != 0) map[y + 1][x + 1]++;
                        }
                    }
                }
            }
            steps++;
            //OutputMap(map);
        }
        while (!map.All(r => r.All(c => c == 0)));
        return steps;
    }

    internal static int[][] GetMap(string filename) =>
        filename.ReadAllLines()
            .Select(line => line.Select(c => c.ToString().ToInt()).ToArray())
            .ToArray();
}
