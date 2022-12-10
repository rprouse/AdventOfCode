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
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
