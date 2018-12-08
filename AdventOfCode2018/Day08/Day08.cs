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
            var nodes = ParseFile(filename);

            int i = 0;
            var meta = new List<int>();
            FindMetaData(nodes, meta, ref i);
            return meta.Sum();
        }

        private static int[] ParseFile(string filename) =>
            filename.ReadFirstLine()
                    .Split(' ', options: System.StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.ToInt())
                    .ToArray();

        public static void FindMetaData(int[] nodes, List<int> meta, ref int i)
        {
            int numChildren = nodes[i++];
            int numMeta = nodes[i++];

            foreach(int child in Enumerable.Range(0, numChildren))
                FindMetaData(nodes, meta, ref i);

            foreach (int m in Enumerable.Range(0, numMeta))
                meta.Add(nodes[i++]);
        }

        public static int PartTwo(string filename)
        {
            var nodes = ParseFile(filename);
            int i = 0;
            var root = new Node(nodes, ref i);
            return root.CalculateValue();
        }

        public class Node
        {
            Node[] _children;
            int[] _metadata;

            public Node(int[] nodes, ref int i)
            {
                int numChildren = nodes[i++];
                int numMeta = nodes[i++];
                _children = new Node[numChildren];
                _metadata = new int[numMeta];

                foreach (int child in Enumerable.Range(0, numChildren))
                    _children[child] = new Node(nodes, ref i);

                foreach (int m in Enumerable.Range(0, numMeta))
                    _metadata[m] = nodes[i++];
            }

            public int CalculateValue()
            {
                if(_children.Length > 0)
                {
                    return _metadata.Where(i => i != 0 && i <= _children.Length)
                        .Select(i => _children[i - 1].CalculateValue())
                        .Sum();
                }
                return _metadata.Sum();
            }
        }
    }
}
