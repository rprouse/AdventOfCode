using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day05
{
    public class Direction
    {
        public Direction(string line)
        {
            var parts = line.Split("->");
            var start = parts[0].Split(',');
            var end = parts[1].Split(',');
            X1 = start[0].ToInt();
            Y1 = start[1].ToInt();
            X2 = end[0].ToInt();
            Y2 = end[1].ToInt();
        }

        public int X1 { get; init; }
        public int Y1 { get; init; }
        public int X2 { get; init; }
        public int Y2 { get; init; }

        public bool Horizontal => Y1 == Y2;
        public bool Vertical => X1 == X2;

        public bool Diagonal =>
            (X1 < X2 && Y1 < Y2) ||
            (X1 > X2 && Y1 > Y2);

        public bool ReverseDiagonal =>
            (X1 < X2 && Y1 > Y2) ||
            (X1 > X2 && Y1 < Y2);

        public bool HorizontalOrVertical => Horizontal || Vertical;
        public int MinX => Math.Min(X1, X2);
        public int MaxX => Math.Max(X1, X2);
        public int MinY => Math.Min(Y1, Y2);
        public int MaxY => Math.Max(Y1, Y2);
    }

    public static int PartOne(string filename)
    {
        var directions = filename
            .ReadAllLines()
            .Select(line => new Direction(line))
            .Where(d => d.HorizontalOrVertical)
            .ToList();
        var maxX = directions.Max(d => d.MaxX) + 1;
        var maxY = directions.Max(d => d.MaxY) + 1;
        int[,] board = new int[maxX, maxY];
        foreach (var d in directions)
        {
            for (int x = d.MinX; x <= d.MaxX; x++)
            {
                for (int y = d.MinY; y <= d.MaxY; y++)
                {
                    board[x, y]++;
                }
            }
        }
        int count = 0;
        for (int y = 0; y < maxY; y++)
        {
            for (int x = 0; x < maxX; x++)
            {
                if (board[x, y] >= 2) count++;
            }
        }
        return count;
    }

    public static int PartTwo(string filename)
    {
        var directions = filename
            .ReadAllLines()
            .Select(line => new Direction(line))
            .ToList();
        var maxX = directions.Max(d => d.MaxX) + 1;
        var maxY = directions.Max(d => d.MaxY) + 1;
        int[,] board = new int[maxX, maxY];
        foreach (var d in directions)
        {
            if (d.Horizontal)
            {
                for (int x = d.MinX; x <= d.MaxX; x++)
                {
                    board[x, d.Y1]++;
                }
            }
            else if (d.Vertical)
            {
                for (int y = d.MinY; y <= d.MaxY; y++)
                {
                    board[d.X1, y]++;
                }
            }
            else if (d.ReverseDiagonal)
            {
                int x = d.MinX;
                int y = d.MaxY;
                for (; x <= d.MaxX && y >= d.MinY; x++, y--)
                {
                    board[x, y]++;
                }
            }
            else if (d.Diagonal)
            {
                int x = d.MinX;
                int y = d.MinY;
                for (; x <= d.MaxX && y <= d.MaxY; x++, y++)
                {
                    board[x, y]++;
                }
            }
            //PrintBoard(board);
        }
        int count = 0;
        for (int y = 0; y < maxY; y++)
        {
            for (int x = 0; x < maxX; x++)
            {
                if (board[x, y] >= 2) count++;
            }
        }
        return count;
    }

    static void PrintBoard(int[,] board)
    {
        for (int y = 0; y < board.GetLength(1); y++)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                Console.Write($"{board[x, y]}");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
