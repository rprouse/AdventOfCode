using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day15
    {
        public static int PartOne(string filename)
        {
            var board = new Board(filename);
            board.Display();
            return 0;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        public class Board
        {
            char[][] _board;

            public int Width => _board[0].Length;

            public int Height => _board.Length;

            public Board(string filename)
            {
                _board = filename.ReadAllLines()
                   .Select(l => l.ToCharArray())
                   .ToArray();
            }

            public IEnumerable<(int x, int y)> Goals(int combatX, int combatY)
            {
                char enemy = _board[combatY][combatX] == 'G' ? 'E' : 'G';
                for(int y = 0; y < Height; y++)
                {
                    for(int x = 0; x < Width; x++)
                    {
                        if(_board[y][x] == enemy)
                        {
                            if (y > 0 && _board[y-1][x] == '.') // Up
                                yield return (x, y - 1);
                            if (y < Height - 1 && _board[y+1][x] == '.') // Down
                                yield return (x, y + 1);
                            if (x > 0 && _board[y][x-1] == '.') // Left
                                yield return (x - 1, y);
                            if (x < Width - 1 && _board[y][x+1] == '.') // Right
                                yield return (x + 1, y);
                        }
                    }
                }
            }

            public void Display()
            {
                Console.Clear();
                foreach (char[] line in _board)
                {
                    foreach (char p in line)
                    {
                        switch (p)
                        {
                            case '#':
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                            case '.':
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            case 'E':
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 'G':
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            default:
                                throw new ArgumentException($"Unknown board character {p}");
                        }
                        Console.Write(p);
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
        }
    }
}
