using System.Drawing;

namespace AdventOfCode2020
{
    public struct Waypoint
    {
        Point _point;

        public Waypoint(int x, int y)
        {
            _point = new Point(x, y);
        }

        public int X => _point.X;

        public int Y => _point.Y;

        public void Offset(int x, int y) =>
            _point.Offset(x, y);

        public void TurnLeft(int degrees)
        {
            _point = degrees switch
            {
                90 => TurnLeft(_point),
                180 => TurnAround(_point),
                270 => TurnRight(_point),
                _ => _point
            };
        }

        public void TurnRight(int degrees)
        {
            _point = degrees switch
            {
                90 => TurnRight(_point),
                180 => TurnAround(_point),
                270 => TurnLeft(_point),
                _ => _point
            };
        }

        static Point TurnLeft(Point waypoint) =>
            new Point(waypoint.Y, -waypoint.X);

        static Point TurnRight(Point waypoint) =>
            new Point(-waypoint.Y, waypoint.X);

        static Point TurnAround(Point waypoint) =>
            new Point(-waypoint.X, -waypoint.Y);
    }
}
