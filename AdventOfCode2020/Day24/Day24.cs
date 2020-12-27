using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day24
    {
        public static int PartOne(string filename)
        {
            var tiles = LayTiles(filename);
            return tiles.Values.Count(t => t);
        }

        private static Dictionary<(int x, int y), bool> LayTiles(string filename)
        {
            string[] lines = filename.ReadAllLines();
            Dictionary<(int x, int y), bool> tiles = new Dictionary<(int x, int y), bool>();
            foreach (var line in lines)
            {
                (int x, int y) = MakeMoves(line);
                if (tiles.ContainsKey((x,y)))
                    tiles[(x, y)] = !tiles[(x, y)];
                else
                    tiles[(x, y)] = true;
            }

            return tiles;
        }

        public static int PartTwo(string filename, bool output = false)
        {
            Dictionary<(int x, int y), bool> tiles = LayTiles(filename);
            Dictionary<(int x, int y), bool> newTiles = new Dictionary<(int x, int y), bool>();

            if (output)
            {
                int minX = tiles.Keys.Min(k => k.x);
                int maxX = tiles.Keys.Max(k => k.x);
                int minY = tiles.Keys.Min(k => k.y);
                int maxY = tiles.Keys.Max(k => k.y);
                for (int y = minY - 1; y <= maxY; y++)
                {
                    if (y % 2 == 0)
                        Console.Write(" ");
                    for (int x = minX - 1; x <= maxX; x++)
                    {
                        Console.Write(IsAlive(tiles, x, y) ? "* " : ". ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            for (int move = 0; move < 100; move++)
            {
                int minX = tiles.Keys.Min(k => k.x);
                int maxX = tiles.Keys.Max(k => k.x);
                int minY = tiles.Keys.Min(k => k.y);
                int maxY = tiles.Keys.Max(k => k.y);
                for (int y = minY - 1; y <= maxY; y++)
                {
                    if (output && y % 2 == 0)
                        Console.Write(" ");
                    for (int x = minX - 1; x <= maxX; x++)
                    {
                        bool alive;
                        int n = AdjecentTiles(tiles, x, y);
                        if (IsAlive(tiles, x, y))
                            alive = n > 0 && n <= 2;
                        else
                            alive = n == 2;

                        if (alive || newTiles.ContainsKey((x, y)))
                            newTiles[(x, y)] = alive;

                        if(output)
                            Console.Write(alive ? "* " : ". ");
                    }
                    if (output)
                        Console.WriteLine();
                }
                (tiles, newTiles) = (newTiles, tiles);
                newTiles.Clear();

                if (output)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Day {move}: {tiles.Values.Count(t => t)}");
                }
            }
            return tiles.Values.Count(t => t);
        }

        internal static int AdjecentTiles(Dictionary<(int x, int y), bool> tiles, int x, int y)
        {
            int c = 0;
            if (IsAlive(tiles, x + 1, y)) c++;   // e
            if (IsAlive(tiles, x + 1, y - 1)) c++;   // ne
            if (IsAlive(tiles, x, y + 1)) c++;   // se
            if (IsAlive(tiles, x - 1, y)) c++;   // w
            if (IsAlive(tiles, x, y - 1)) c++;   // nw
            if (IsAlive(tiles, x - 1, y + 1)) c++;   // sw
            return c;
        }

        internal static bool IsAlive(Dictionary<(int x, int y), bool> tiles, int x, int y) =>
            tiles.ContainsKey((x, y)) ? tiles[(x, y)] : false;

        internal static (int x, int y) MakeMoves(string moves)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == 'n' || moves[i] == 's')
                {
                    (x, y) = Step(x, y, moves[i..(i + 2)]);
                    i++;
                }
                else
                {
                    (x, y) = Step(x, y, moves[i..(i + 1)]);
                }
            }
            return (x, y);
        }

        internal static (int x, int y) Step(int x, int y, string step) =>
            step switch
            {
                "e" => (x + 1, y),
                "ne" => (x + 1, y - 1),
                "se" => (x, y + 1),
                "w" => (x - 1, y),
                "nw" => (x, y - 1),
                "sw" => (x - 1, y + 1),
                _ => throw new ArgumentException()
            };
    }
}
