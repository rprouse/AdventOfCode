using System.Drawing;

namespace AdventOfCode.Core.Routing
{
    /// <summary>
    /// A point in a graph with a cost for routing
    /// </summary>
    public struct Node
    {
        public Node(Point point, int cost)
        {
            Point = point;
            Cost = cost;
        }

        public Point Point { get; init; }
        public int Cost { get; init; }
    }
}
