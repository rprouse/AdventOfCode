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
            List<Point> queue = new List<Point>();
            Dictionary<Point, int> dist = new Dictionary<Point, int>();
            Dictionary<Point, Point> prev = new Dictionary<Point, Point>();

            for (int y = 0; y < _graph.GetLength(1); y++)
            {
                for (int x = 0; x < _graph.GetLength(0); x++)
                {
                    Point p = new Point(x, y);
                    dist[p] = int.MaxValue;
                    queue.Add(p);
                }
            }
            dist[start] = 0;

            while (queue.Count > 0)
            {
                // TODO: This is inefficient, use a priority queue?
                int min = queue.Min(p => dist[p]);
                Point u = queue.First(p => dist[p] == min);

                queue.Remove(u);

                // If u is the target, return the distance to it
                if (u == end)
                    return dist[prev[u]] + _graph[end.X, end.Y];

                // foreach neighbor still in queue
                foreach (Point v in u.Neighbors(_width, _height).Where(p => queue.Contains(p)))
                {
                    var alt = dist[u] + _graph[v.X, v.Y];
                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        prev[v] = u;
                    }
                }
            }
            return 0;
        }
    }
}
