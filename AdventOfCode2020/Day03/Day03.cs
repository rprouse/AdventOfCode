using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day03
    {
        public static int PartOne(string filename, int right, int down)
        {
            string[] lines = filename.ReadAllLines();
            int trees = 0;
            for(int x = right, y = down; y < lines.Length; x += right, y += down)
            {
                if (lines[y][x % lines[0].Length] == '#')
                    trees++;
            }
            return trees;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
