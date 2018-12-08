using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day08
    {
        public static int PartOne(string filename)
        {
            int[] nodes = filename.ReadFirstLine()
                    .Split(' ', options: System.StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.ToInt())
                    .ToArray();

            int i = 0;
            var meta = new List<int>();
            FindMetaData(nodes, meta, ref i);
            return meta.Sum();
        }

        public static void FindMetaData(int[] nodes, List<int> meta, ref int i)
        {
            int numChildren = nodes[i++];
            int numMeta = nodes[i++];

            foreach(int child in Enumerable.Range(0, numChildren))
            {
                FindMetaData(nodes, meta, ref i);
            }

            foreach (int m in Enumerable.Range(0, numMeta))
            {
                meta.Add(nodes[i++]);
            }
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
