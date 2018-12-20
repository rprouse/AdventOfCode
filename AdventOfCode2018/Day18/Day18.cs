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
            foreach (int i in Enumerable.Range(0, 10))
            {
                //acres.Display();
                acres = acres.Grow();
            }
            acres.Display();

            return acres.Value();
        }

        public static int PartTwo(string filename)
        {
            char[][] acres = filename.ReadAllLines().Select(l => l.ToCharArray()).ToArray();
            var past = new List<char[][]>();
            past.Add(acres);
            foreach (int i in Enumerable.Range(0, 10000))
            {
                acres = acres.Grow();
                int first = acres.Matches(past);
                if(first != -1)
                {
                    var j = FindIndex(1000000000, first, i + 1);

                    Enumerable.Range(j - 4, 8).ForEach(k => Console.WriteLine($"{k} value {past[k].Value()}"));
                    return past[j].Value();
                }
                past.Add(acres);
            }
            return 0;
        }

        private static int Value(this char[][] acres) =>
            acres.NumberOf('|') * acres.NumberOf('#');

        internal static int FindIndex(int max, int first, int second)
        {
            int offset = max - first;
            int cycle = second - first;
            int numCycle = offset / cycle;
            int end = cycle * numCycle + first;
            return max - end + first;
        }

        static int Matches(this char[][] acres, IList<char[][]> past)
        {
            for (int i = 0; i < past.Count; i++)
            {
                if (acres.Matches(past[i])) return i;
            }
            return -1;
        }

        static bool Matches(this char[][] acres, char[][] other)
        {
            for (int y = 0; y < acres.Length; y++)
            {
                for (int x = 0; x < acres[y].Length; x++)
                {
                    if (acres[y][x] != other[y][x]) return false;
                }
            }
            return true;
        }

        static char[][] Grow(this char[][] acres)
        {
            char[][] next = new char[acres.Length][];
            for (int y = 0; y < acres.Length; y++)
            {
                next[y] = new char[acres[y].Length];
                for (int x = 0; x < acres[y].Length; x++)
                {
                    switch (acres[y][x])
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
            if (x > 0)
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
