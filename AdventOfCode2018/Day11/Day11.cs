using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day11
    {
        public static (int x, int y) PartOne(int serial)
        {
            int[,] grid = new int[300,300];
            foreach (int x in Enumerable.Range(0, 300))
                foreach (int y in Enumerable.Range(0, 300))
                    grid[x, y] = CalculatePower(x + 1, y + 1, serial);

            int maxSum = 0;
            int maxX = -1;
            int maxY = -1;
            foreach (int x in Enumerable.Range(0, 297))
            {
                foreach (int y in Enumerable.Range(0, 297))
                {
                    int sum = grid[x, y] + grid[x, y + 1] + grid[x, y + 2] +
                        grid[x + 1, y] + grid[x + 1, y + 1] + grid[x + 1, y + 2] +
                        grid[x + 2, y] + grid[x + 2, y + 1] + grid[x + 2, y + 2];
                    if(sum > maxSum)
                    {
                        maxSum = sum;
                        maxX = x + 1;
                        maxY = y + 1;
                    }
                }
            }
            return (maxX, maxY);
        }

        public static int PartTwo(string filename)
        {
            return 0;
        }

        public static int CalculatePower(int x, int y, int serial) =>
            (((x + 10) * y + serial) * (x + 10) / 100 % 10) - 5;
    }
}
