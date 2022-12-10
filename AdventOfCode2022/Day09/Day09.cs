using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day09
{
    public static int PartOne(string filename) =>
        CalculateVisited(filename, 2);

    public static int PartTwo(string filename) =>
        CalculateVisited(filename, 10);

    private static int CalculateVisited(string filename, int numPoints)
    { 
        var visited = new List<Point>();
        var points = new Point[numPoints];
        visited.Add(points[points.Length - 1]);
        string[] lines = filename.ReadAllLines();
        foreach (string line in lines)
        {
            char dir = line[0];
            int steps = line.Substring(2).ToInt();
            foreach (var _ in Enumerable.Range(0, steps))
            {
                MoveHead(points, dir);
                MoveTails(points);

                if (!visited.Contains(points[points.Length - 1]))
                    visited.Add(points[points.Length - 1]);
            }
        }
        return visited.Count;
    }

    private static void MoveHead(Point[] points, char dir)
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
    }

    private static void MoveTails(Point[] points)
    {
        for (int i = 1; i < points.Length; i++)
        {
            if (IsOneAwayFromPreviousPoint(points, i)) continue;
            MoveTail(points, i);
        }
    }

    private static bool IsOneAwayFromPreviousPoint(Point[] points, int i) =>
        Math.Abs(points[i - 1].X - points[i].X) <= 1 &&
        Math.Abs(points[i - 1].Y - points[i].Y) <= 1;


    private static void MoveTail(Point[] points, int i)
    {
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
}
