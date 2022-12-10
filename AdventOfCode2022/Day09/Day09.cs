using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Drawing;

namespace AdventOfCode2022;

public static class Day09
{
    public static int PartOne(string filename)
    {
        var visited = new List<Point>();
        var head = new Point(0, 0);
        var tail = new Point(0, 0);
        visited.Add(tail);
        string[] lines = filename.ReadAllLines();
        foreach(string line in lines)
        {
            char dir = line[0];
            int steps = line.Substring(2).ToInt();
            foreach(var _ in Enumerable.Range(0, steps))
            {
                switch (dir)
                {
                    case 'R':
                        head.Offset(1, 0);
                        break;
                    case 'L':
                        head.Offset(-1, 0);
                        break;
                    case 'U':
                        head.Offset(0, 1);
                        break;
                    case 'D':
                        head.Offset(0, -1);
                        break;
                }
                if (Math.Abs(head.X - tail.X) <= 1 && Math.Abs(head.Y - tail.Y) <= 1)
                {
                    continue;
                }
                if (head.X > tail.X)
                {
                    tail.Offset(1, 0);
                }
                else if (head.X < tail.X)
                {
                    tail.Offset(-1, 0);
                }
                if (head.Y > tail.Y)
                {
                    tail.Offset(0, 1);
                }
                else if (head.Y < tail.Y)
                {
                    tail.Offset(0, -1);
                }
                if (!visited.Contains(tail))
                {
                    visited.Add(tail);
                }
            }
        }
        return visited.Count;
    }

    public static int PartTwo(string filename)
    {
        var visited = new List<Point>();
        var points = new Point[10];
        visited.Add(points[9]);
        string[] lines = filename.ReadAllLines();
        foreach (string line in lines)
        {
            char dir = line[0];
            int steps = line.Substring(2).ToInt();
            foreach (var _ in Enumerable.Range(0, steps))
            {
                switch (dir)
                {
                    case 'R':
                        points[0].Offset(1, 0);
                        break;
                    case 'L':
                        points[0].Offset(-1, 0);
                        break;
                    case 'U':
                        points[0].Offset(0, 1);
                        break;
                    case 'D':
                        points[0].Offset(0, -1);
                        break;
                }
                for (int i = 1; i < 10; i++)
                {
                    if (Math.Abs(points[i - 1].X - points[i].X) <= 1 &&
                        Math.Abs(points[i - 1].Y - points[i].Y) <= 1)
                    {
                        continue;
                    }
                    if (points[i - 1].X > points[i].X)
                    {
                        points[i].Offset(1, 0);
                    }
                    else if (points[i - 1].X < points[i].X)
                    {
                        points[i].Offset(-1, 0);
                    }
                    if (points[i - 1].Y > points[i].Y)
                    {
                        points[i].Offset(0, 1);
                    }
                    else if (points[i - 1].Y < points[i].Y)
                    {
                        points[i].Offset(0, -1);
                    }
                }
                if (!visited.Contains(points[9]))
                {
                    visited.Add(points[9]);
                }
            }
        }
        return visited.Count;
    }
}
