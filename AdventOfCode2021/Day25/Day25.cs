using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day25
{
    public static int PartOne(string filename)
    {
        char[][] cucumbers = filename
            .ReadAllLines()
            .Select(l => l.ToArray())
            .ToArray();

        char[][] next = new char[cucumbers.Length][];
        char[][] swap;

        int moves = 0;
        bool moved = true;
        while (moved)
        {
            moved = false;
            next[0] = new char[cucumbers[0].Length];
            for (int y = 0; y < cucumbers.Length; y++)
            {
                if (y < cucumbers.Length - 1)
                    next[y + 1] = new char[cucumbers[y + 1].Length];

                for (int x = 0; x < cucumbers[y].Length; x++)
                {
                    switch (cucumbers[y][x])
                    {
                        case '.':
                            if (next[y][x] == '\0')
                                next[y][x] = '.';
                            break;
                        case '>':
                            if (x == cucumbers[y].Length - 1 && cucumbers[y][0] == '.')
                            {
                                moved = true;
                                next[y][x] = '.';
                                next[y][0] = '>';
                            }
                            else if (x < cucumbers[y].Length - 1 && cucumbers[y][x + 1] == '.')
                            {
                                moved = true;
                                next[y][x] = '.';
                                next[y][x + 1] = '>';
                            }
                            else
                            {
                                next[y][x] = '>';
                            }
                            break;
                        case 'v':
                            if (y == cucumbers.Length - 1 && cucumbers[0][x] == '.')
                            {
                                moved = true;
                                next[y][x] = '.';
                                next[0][x] = 'v';
                            }
                            else if (y < cucumbers.Length - 1 && cucumbers[y + 1][x] == '.')
                            {
                                moved = true;
                                next[y][x] = '.';
                                next[y + 1][x] = 'v';
                            }
                            else
                            {
                                next[y][x] = '>';
                            }
                            break;
                    }
                }
            }
            swap = cucumbers;
            cucumbers = next;
            next = swap;
            if (moved) moves++;

            if (moves <= 5 || moves % 10 == 0 || moves >= 55)
            {
                Console.WriteLine($"Moves: {moves}");
                Display(cucumbers);
            }
            if (moves == 60)
                break;
        }
        return moves;
    }

    static void Display(char[][] cucumbers)
    {
        for (int y = 0; y < cucumbers.Length; y++)
        {
            for (int x = 0; x < cucumbers[y].Length; x++)
            {
                Console.Write(cucumbers[y][x]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
