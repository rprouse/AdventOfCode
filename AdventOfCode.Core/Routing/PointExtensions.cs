using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode.Core.Routing
{
    public static class PointExtensions
    {
        public static IEnumerable<Point> Neighbors(this Point p, int width, int height, bool includeDiagonals = false)
        {
            if (p.X < width - 1) yield return new Point(p.X + 1, p.Y);
            if (p.X > 0) yield return new Point(p.X - 1, p.Y);
            if (p.Y > 0) yield return new Point(p.X, p.Y - 1);
            if (p.Y < height - 1) yield return new Point(p.X, p.Y + 1);

            if(includeDiagonals)
            {
                if(p.X < width - 1 && p.Y < height - 1) yield return new Point(p.X + 1, p.Y + 1);
                if (p.X > 0 && p.Y < height - 1) yield return new Point(p.X - 1, p.Y + 1);
                if (p.X < width - 1 && p.Y > 0) yield return new Point(p.X + 1, p.Y - 1);
                if (p.X > 0 && p.Y > 0) yield return new Point(p.X - 1, p.Y - 1);
            }
        }

        public static bool InGraph(this Point point, int[,] graph) =>
            point.X >= 0 &&
            point.Y >= 0 &&
            point.X < graph.GetLength(0) &&
            point.Y < graph.GetLength(1);
    }
}
