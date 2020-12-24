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
            string[] lines = filename.ReadAllLines();
            Dictionary<string, bool> tiles = new Dictionary<string, bool>();
            foreach(var line in lines)
            {
                (int x, int y) = MakeMoves(line);

                string tile = $"{x},{y}";
                if (tiles.ContainsKey(tile))
                    tiles[tile] = !tiles[tile];
                else
                    tiles[tile] = true;
            }
            return tiles.Values.Count(t => t);
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

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
