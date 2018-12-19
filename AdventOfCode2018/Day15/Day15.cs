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
            internal const char WALL = '#';
            internal const char OPEN = '.';
            internal const char GOBLIN = 'G';
            internal const char ELF = 'E';

            char[][] _board;

            public char this[int x, int y]
            {
                get { return _board[y][x]; }
                set { _board[y][x] = value; }
            }

            public int Width => _board[0].Length;

            public int Height => _board.Length;

            public Board(string filename)
            {
                _board = filename.ReadAllLines()
                   .Select(l => l.ToCharArray())
                   .ToArray();
            }

            // Makes one turn for every player on the board
            public bool Turn()
            {
                return false;
            }

            // Makes one turn for the given player
            internal void Turn(int x, int y)
            {
                var players = GetPlayers().ToArray();
                foreach(var player in players)
                {
                    char enemy = DetermineEnemy(player.x, player.y);
                }
            }

            internal IEnumerable<(char p, int x, int y)> GetPlayers()
            {
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (this[x, y] == GOBLIN || this[x,y] == ELF)
                        {
                            yield return (this[x, y], x, y);
                        }
                    }
                }
            }

            internal IEnumerable<(char p, int x, int y)> GetEnemies(int combatX, int combatY)
            {
                char enemy = DetermineEnemy(combatX, combatY);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (this[x, y] == enemy)
                        {
                            yield return (this[x, y], x, y);
                        }
                    }
                }
            }



            internal IEnumerable<(int x, int y)> Goals(int combatX, int combatY)
            {
                var enemy = DetermineEnemy(combatX, combatY);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (this[x, y] == enemy)
                        {
                            if (y > 0 && this[x, y - 1] == OPEN) // Up
                                yield return (x, y - 1);
                            if (y < Height - 1 && this[x, y + 1] == OPEN) // Down
                                yield return (x, y + 1);
                            if (x > 0 && this[x - 1, y] == OPEN) // Left
                                yield return (x - 1, y);
                            if (x < Width - 1 && this[x + 1, y] == OPEN) // Right
                                yield return (x + 1, y);
                        }
                    }
                }
            }

            internal char DetermineEnemy(int x, int y) =>
                this[x, y] == GOBLIN ? ELF : GOBLIN;

            internal bool CanAttack(int x, int y)
            {
                var enemy = DetermineEnemy(x, y);
                if (y > 0 && this[x, y - 1] == enemy) // Up
                    return true;
                if (y < Height - 1 && this[x, y + 1] == enemy) // Down
                    return true;
                if (x > 0 && this[x - 1, y] == enemy) // Left
                    return true;
                if (x < Width - 1 && this[x + 1, y] == enemy) // Right
                    return true;
                return false;
            }

            internal static int Distance(int x1, int y1, int x2, int y2) =>
                Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

            public void Display()
            {
                Console.Clear();
                foreach (char[] line in _board)
                {
                    foreach (char p in line)
                    {
                        switch (p)
                        {
                            case WALL:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                            case OPEN:
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            case ELF:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case GOBLIN:
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
