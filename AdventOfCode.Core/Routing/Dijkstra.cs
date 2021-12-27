using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Core.Routing
{
    // https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Pseudocode
    public class Dijkstra
    {
        private readonly int[,] _graph;
        private readonly int _width;
        private readonly int _height;

        public Dijkstra(int[,] graph)
        {
            _graph = graph;
            _width = graph.GetLength(0);
            _height = graph.GetLength(1);
        }

        public int ShortestDistance(Point start, Point end)
        {
            var queue = new PriorityQueue<Point, int>();
            var dist = new Dictionary<Point, int>();
            var prev = new Dictionary<Point, Point>();

            queue.Enqueue(start, 0);
            dist[start] = 0;

            while (queue.Count > 0)
            {
                Point u = queue.Dequeue();

                // If u is the target, return the distance to it
                if (u == end)
                    return dist[prev[u]] + _graph[end.X, end.Y];

                // foreach neighbor still in queue
                foreach (Point v in u.Neighbors(_width, _height))
                {
                    var alt = dist[u] + _graph[v.X, v.Y];
                    if (!dist.ContainsKey(v) || alt < dist[v])
                    {
                        dist[v] = alt;
                        prev[v] = u;
                        queue.Enqueue(v, alt);
                    }
                }
            }
            return 0;
        }
    }
}
