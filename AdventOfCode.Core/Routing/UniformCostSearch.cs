using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Routing
{
    // https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Practical_optimizations_and_infinite_graphs
    public class UniformCostSearch
    {
        private readonly int[,] _graph;
        private readonly int _width;
        private readonly int _height;

        public UniformCostSearch(int[,] graph)
        {
            _graph = graph;
            _width = graph.GetLength(0);
            _height = graph.GetLength(1);
        }

        public int ShortestDistance(Point start, Point end)
        {
            Node node = new Node(start, 0);
            var frontier = new PriorityQueue<Node, int>();
            frontier.Enqueue(node, 0);
            bool[,] explored = new bool[_graph.GetLength(0), _graph.GetLength(1)];

            while (true)
            {
                if (frontier.Count == 0)
                    throw new Exception("Failed to find UCS route");

                node = frontier.Dequeue();
                if (node.Point == end)
                {
                    return node.Cost;
                }
                explored[node.Point.X, node.Point.Y] = true;
                foreach (var neighbor in node.Point.Neighbors(_width, _height))
                {
                    if (!explored[neighbor.X, neighbor.Y])
                    {
                        var neighborNode = new Node(neighbor, _graph[neighbor.X, neighbor.Y] + node.Cost);
                        frontier.Enqueue(neighborNode, neighborNode.Cost);
                    }
                }
            }
        }
    }
}
