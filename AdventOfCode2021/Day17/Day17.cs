using System;
using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode2021;

public static class Day17
{
    public static int PartOne(TargetArea targetArea)
    {
        // Calculate the range of X that might work, I'm
        // looking for an X velocity where X will be falling
        // straight down by the time it hits the square
        List<int> possibleX = new List<int>();
        for (int x = 1; x <= targetArea.TargetMin.X; x++)
        {
            var xLoc = 0;
            var xVel = x;
            while (xVel > 0)
            {
                xLoc += xVel;
                xVel--;
            }
            if (xLoc >= targetArea.TargetMin.X && xLoc <= targetArea.TargetMax.X)
                possibleX.Add(x);
        }
        // Using these possible X values, let's try some Y's
        int maxY = 0;
        foreach (int x in possibleX)
        {
            for(int y = x / 2; y <= Math.Abs(targetArea.TargetMin.Y); y++)
            {
                int localMaxY = 0;
                bool hitTarget = false;
                var probe = new Probe(x, y);
                do
                {
                    probe.Step();
                    if (probe.Y > localMaxY)
                        localMaxY = probe.Y;

                    if(probe.InTargetArea(targetArea))
                    {
                        hitTarget = true;
                        break;
                    }
                }
                while (probe.LessThanTargetArea(targetArea));

                if (hitTarget && localMaxY > maxY)
                    maxY = localMaxY;
            }
        }
        return maxY;
    }

    public static int PartTwo(TargetArea targetArea)
    {
        int hits = 0;
        // Possible X values are all positive and don't overshoot
        for(int x = 1; x <= targetArea.TargetMax.X; x++)
        {
            // Possible Y values
            for(int y = targetArea.TargetMin.Y; y <= Math.Abs(targetArea.TargetMin.Y); y++)
            {
                var probe = new Probe(x, y);
                do
                {
                    probe.Step();

                    if (probe.InTargetArea(targetArea))
                    {
                        hits++;
                        break;
                    }
                }
                while (probe.LessThanTargetArea(targetArea));
            }
        }
        return hits;
    }

    public class Probe
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int XVelocity { get; set; }
        public int YVelocity { get; set; }

        public override string ToString() =>
            $"Loc: ({X},{Y}), Vel: ({XVelocity},{YVelocity})";

        public Probe(int xVelocity, int yVelocity)
        {
            XVelocity = xVelocity;
            YVelocity = yVelocity;
        }

        public void Step()
        {
            X += XVelocity;
            Y += YVelocity;
            XVelocity = XVelocity switch
            {
                > 0 => XVelocity - 1,
                0 => 0,
                < 0 => XVelocity + 1,
            };
            YVelocity--;
        }

        public bool LessThanTargetArea(TargetArea area) =>
            X <= area.TargetMax.X &&
            Y >= area.TargetMin.Y;

        public bool InTargetArea(TargetArea area) =>
            LessThanTargetArea(area) &&
            X >= area.TargetMin.X &&
            Y <= area.TargetMax.Y;
    }

    public class TargetArea
    {
        public Point TargetMin { get; set; }
        public Point TargetMax { get; set; }

        public TargetArea(int x1, int x2, int y1, int y2)
        {
            TargetMin = new Point(x1, y1);
            TargetMax = new Point(x2, y2);
        }
    }
}
