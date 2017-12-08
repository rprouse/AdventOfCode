using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public static class Day6
    {
        public static int CountReallocations(this int[] blocks)
        {
            var comparer = new IntArrayComparer();
            int count = 0;
            var previous = new List<int[]>();
            previous.Add(blocks);
            do
            {
                count++;
                blocks = blocks.Reallocate();
                if (previous.Contains(blocks, comparer)) break;
                previous.Add(blocks);

            } while (true);

            return count;
        }

        class IntArrayComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] x, int[] y)
            {
                if (x == null && y == null) return true;
                if (x == null || y == null) return false;
                if (x.Length != y.Length) return false;
                for (int i = 0; i < x.Length; i++)
                    if (x[i] != y[i]) return false;

                return true;
            }

            public int GetHashCode(int[] obj) =>
                obj.Aggregate((working, next) => working ^ next.GetHashCode());
        }

        static int[] Reallocate(this int[] blocks)
        {
            int[] copy = new int[blocks.Length];
            blocks.CopyTo(copy, 0);

            int pos = copy.IndexOfMax();
            int block = copy[pos];
            copy[pos++] = 0;
            while(block > 0)
            {
                copy[pos++ % blocks.Length]++;
                block--;
            }
            return copy;
        }

        static int IndexOfMax(this int[] blocks)
        {
            int max = blocks.Max();
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] == max) return i;
            }
            return -1;
        }
    }
}
