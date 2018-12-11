using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public static class Day10
    {
        public static void PartOne(string filename, int start)
        {
            Point[] points = filename
                .ReadAllLines()
                .Select(l => new Point(l))
                .ToArray();

            for (int i = start; i < start + 100; i++)
            {
                foreach (Point point in points)
                {
                    (int x, int y) = point.Step(i);
                    if (x < 0 || y < 0 || x >= Console.BufferWidth || y >= Console.BufferHeight) continue;
                    Console.SetCursorPosition(x, y);
                    Console.Write('#');
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        public class Point
        {
            public int X { get; }
            public int Y { get; }

            public int XV { get; }
            public int YV { get; }

            static Regex regex = new Regex(@"position=<\s*(-?\d+),\s*(-?\d+)> velocity=<\s*(-?\d+),\s*(-?\d+)>", RegexOptions.Compiled);
            public Point(string line)
            {
                var match = regex.Match(line);
                if(match.Success)
                {
                    X = match.GetInt(1);
                    Y = match.GetInt(2);
                    XV = match.GetInt(3);
                    YV = match.GetInt(4);
                }
            }

            public (int x, int y) Step(int sec) =>
                (X - 128 + XV * sec, Y - 116 + YV * sec);
        }
    }
}
