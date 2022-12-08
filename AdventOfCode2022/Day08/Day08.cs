using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day08
{
    public static int PartOne(string filename)
    {
        int[,] trees = ParseTrees(filename);
        int count = 0;
        int xMax = trees.GetLength(0);
        int yMax = trees.GetLength(1);
        for (int y = 0; y < yMax; y++)
        {
            for (int x = 0; x < xMax; x++)
            {
                // On Edge
                if (x == 0 || y == 0 || x == xMax - 1 || y == yMax - 1)
                {
                    count++;
                    continue;
                }
                // Can see left
                bool taller = false;
                for (int x1 = 0; x1 < x; x1++)
                {
                    if (trees[x1,y] >= trees[x,y])
                    {
                        taller = true;
                        break;
                    }
                }
                if (!taller)
                {
                    count++;
                    continue;
                }

                // Can see right
                taller = false;
                for (int x1 = x + 1; x1 < xMax; x1++)
                {
                    if (trees[x1, y] >= trees[x, y])
                    {
                        taller = true;
                        break;
                    }
                }
                if (!taller)
                {
                    count++;
                    continue;
                }

                // Can see up
                taller = false;
                for (int y1 = 0; y1 < y; y1++)
                {
                    if (trees[x, y1] >= trees[x, y])
                    {
                        taller = true;
                        break;
                    }
                }
                if (!taller)
                {
                    count++;
                    continue;
                }

                // Can see down
                taller = false;
                for (int y1 = y + 1; y1 < yMax; y1++)
                {
                    if (trees[x, y1] >= trees[x, y])
                    {
                        taller = true;
                        break;
                    }
                }
                if (!taller) count++;
            }
        }
        return count;
    }

    public static int[,] ParseTrees(string filename)
    {
        string[] lines = filename.ReadAllLines();
        int[,] trees = new int[lines[0].Length, lines.Length];
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                trees[x, y] = lines[y][x].ToInt();
            }
        }
        return trees;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
