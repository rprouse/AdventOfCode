using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day08
    {
        public static int PartOne(string filename) =>
            new Node(filename).SumMetaData();

        public static int PartTwo(string filename) =>
            new Node(filename).CalculateValue();

        public class Node
        {
            Node[] _children;
            int[] _metadata;

            public Node() { }

            public Node(string filename)
            {
                int i = 0;
                ParseNodes(ParseFile(filename), ref i);
            }

            private static int[] ParseFile(string filename) =>
                filename.ReadFirstLine()
                        .Split(' ', options: System.StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.ToInt())
                        .ToArray();

            private Node ParseNodes(int[] nodes, ref int i)
            {
                _children = new Node[nodes[i++]];
                _metadata = new int[nodes[i++]];

                foreach (int child in Enumerable.Range(0, _children.Length))
                    _children[child] = new Node().ParseNodes(nodes, ref i);

                foreach (int m in Enumerable.Range(0, _metadata.Length))
                    _metadata[m] = nodes[i++];

                return this;
            }

            public int SumMetaData() =>
                _children.Select(c => c.SumMetaData()).Sum() + _metadata.Sum();

            public int CalculateValue() =>
                _children.Length == 0 ?
                    _metadata.Sum() :
                    _metadata.Where(i => i != 0 && i <= _children.Length)
                        .Select(i => _children[i - 1].CalculateValue())
                        .Sum();
        }
    }
}
