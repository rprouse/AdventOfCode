using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

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
}
