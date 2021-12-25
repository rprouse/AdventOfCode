using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day22
{
    public static long PartOne(string filename, bool reduce)
    {
        var steps = filename.ReadAllLines()
            .Select(line => new RebootStep(line, reduce))
            .ToArray();

        var reactor = new HashSet<long>();
        foreach (var step in steps)
        {
            for (int z = step.Z1; z <= step.Z2; z++)
            {
                for (int y = step.Y1; y <= step.Y2; y++)
                {
                    for (int x = step.X1; x <= step.X2; x++)
                    {
                        long index = x + y << 24 + z << 48;
                        if (step.On)
                        {
                            reactor.Add(index);
                        }
                        else
                        {
                            reactor.Remove(index);

                        }
                    }
                }
            }
        }
        return reactor.LongCount();
    }

    public class RebootStep
    {
        public bool On { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int Z1 { get; set; }
        public int Z2 { get; set; }

        public RebootStep(string step, bool reduce)
        {
            On = step.StartsWith("on");
            Parse(step.Substring(On ? 3 : 4));
            if (reduce) Reduce();
        }

        void Reduce()
        {
            X1 = Math.Max(X1, -50);
            Y1 = Math.Max(Y1, -50);
            Z1 = Math.Max(Z1, -50);
            X2 = Math.Min(X2, 50);
            Y2 = Math.Min(Y2, 50);
            Z2 = Math.Min(Z2, 50);
        }

        void Parse(string line)
        {
            string[] parts = line.Split(',');
            (X1, X2) = ParsePart(parts[0]);
            (Y1, Y2) = ParsePart(parts[1]);
            (Z1, Z2) = ParsePart(parts[2]);
        }

        static (int i1, int i2) ParsePart(string part)
        {
            part = part.Substring(2);
            string[] parts = part.Split("..");
            return (parts[0].ToInt(), parts[1].ToInt());
        }
    }
}
