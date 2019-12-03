using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day03
    {
        const int SIZE = 13000;

        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return PartOne(lines[0], lines[1]);
        }

        public static int PartOne(string wire1, string wire2)
        {
            bool[,] path1 = FollowWire(wire1);
            bool[,] path2 = FollowWire(wire2);
            int minDist = int.MaxValue;

            for(int x = 0; x < SIZE * 2; x++)
            for(int y = 0; y < SIZE * 2; y++)
            {
                if(path1[x,y] && path2[x,y])
                {
                    int d = Distance(x, y);
                    if (d < minDist)
                        minDist = d;
                }
            }

            return minDist;
        }

        static int Distance(int x, int y) =>
            Math.Abs(SIZE - x) + Math.Abs(SIZE - y);

        static bool[,] FollowWire(string wire)
        {
            bool[,] board = new bool[SIZE * 2, SIZE * 2];

            int x = SIZE;
            int y = SIZE;

            string[] steps = wire.Split(",", StringSplitOptions.RemoveEmptyEntries);

            foreach(string step in steps)
            {
                char dir = step[0];
                int dist = step.Substring(1).ToInt();
                switch(dir)
                {
                    case 'U':
                        for(int c = 0; c < dist; c++)
                        {
                            board[x, --y] = true;
                        }
                        break;
                    case 'D':
                        for (int c = 0; c < dist; c++)
                        {
                            board[x, ++y] = true;
                        }
                        break;
                    case 'L':
                        for (int c = 0; c < dist; c++)
                        {
                            board[--x, y] = true;
                        }
                        break;
                    case 'R':
                        for (int c = 0; c < dist; c++)
                        {
                            board[++x, y] = true;
                        }
                        break;
                }
            }

            return board;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
