using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day18
    {
        public static int PartOne(string filename)
        {
            char[][] acres = filename.ReadAllLines().Select(l => l.ToCharArray()).ToArray();
            acres.Display();
            foreach (int i in Enumerable.Range(0, 10))
            {
                acres = acres.Grow();
                acres.Display();
            }

            return acres.NumberOf('|') * acres.NumberOf('#');
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        static char[][] Grow(this char[][] acres)
        {
            char[][] next = new char[acres.Length][];
            for(int y = 0; y < acres.Length; y++)
            {
                next[y] = new char[acres[y].Length];
                for(int x = 0; x < acres[y].Length; x++)
                {
                    switch(acres[y][x])
                    {
                        case '|':
                            next[y][x] = acres.Neighboors(x, y).Count(n => n == '#') >= 3 ? '#' : '|';
                            break;
                        case '#':
                            next[y][x] = acres.Neighboors(x, y).Count(n => n == '#') >= 1 &&
                                acres.Neighboors(x, y).Count(n => n == '|') >= 1 ? '#' : '.';
                            break;
                        case '.':
                            next[y][x] = acres.Neighboors(x, y).Count(n => n == '|') >= 3 ? '|' : '.';
                            break;
                    }
                }
            }
            return next;
        }

        static IEnumerable<char> Neighboors(this char[][] acres, int x, int y)
        {
            if(x > 0)
            {
                yield return acres[y][x - 1];
                if (y > 0)
                    yield return acres[y - 1][x - 1];
                if (y < acres.Length - 1)
                    yield return acres[y + 1][x - 1];
            }
            if (x < acres[y].Length - 1)
            {
                yield return acres[y][x + 1];
                if (y > 0)
                    yield return acres[y - 1][x + 1];
                if (y < acres.Length - 1)
                    yield return acres[y + 1][x + 1];
            }
            if (y > 0)
                yield return acres[y - 1][x];
            if (y < acres.Length - 1)
                yield return acres[y + 1][x];
        }

        static void Display(this char[][] acres)
        {
            foreach (char[] a in acres)
                Console.WriteLine(new string(a));
            Console.WriteLine();
        }

        static int NumberOf(this char[][] acres, char search) =>
            acres.Select(a => a.Where(c => c == search).Count()).Sum();
    }
}
