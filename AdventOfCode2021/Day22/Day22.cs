using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day22
{
    public static int PartOne(string filename)
    {
        string[] lines = filename.ReadAllLines();
        var reactor = new HashSet<(int x, int y, int z)>();
        foreach(var line in lines)
        {
            if(line.StartsWith("on"))
            {
                (int x1, int x2, int y1, int y2, int z1, int z2) =
                    Parse(line.Substring(3));

                (x1, x2, y1, y2, z1, z2) = 
                    ReduceTo(x1, x2, y1, y2, z1, z2, -50, 50);

                for (int z = z1; z <= z2; z++)
                {
                    for (int y = y1; y <= y2; y++)
                    {
                        for (int x = x1; x <= x2; x++)
                        {
                            if(!reactor.Contains((x, y, z)))
                                reactor.Add((x, y, z));
                        }
                    }
                }
            }
            else
            {
                (int x1, int x2, int y1, int y2, int z1, int z2) =
                    Parse(line.Substring(4));

                (x1, x2, y1, y2, z1, z2) =
                    ReduceTo(x1, x2, y1, y2, z1, z2, -50, 50);

                for (int z = z1; z <= z2; z++)
                {
                    for (int y = y1; y <= y2; y++)
                    {
                        for (int x = x1; x <= x2; x++)
                        {
                            if (reactor.Contains((x, y, z)))
                                reactor.Remove((x, y, z));
                        }
                    }
                }
            }
        }
        return reactor.Count;
    }

    static (int x1, int x2, int y1, int y2, int z1, int z2) ReduceTo(int x1, int x2, int y1, int y2, int z1, int z2, int min, int max)
    {
        x1 = Math.Max(x1, min);
        y1 = Math.Max(y1, min);
        z1 = Math.Max(z1, min);
        x2 = Math.Min(x2, max);
        y2 = Math.Min(y2, max);
        z2 = Math.Min(z2, max);
        return (x1, x2, y1, y2, z1, z2);
    }

    static (int x1, int x2, int y1, int y2, int z1, int z2) Parse(string line)
    {
        string[] parts = line.Split(',');
        (int x1, int x2) = ParsePart(parts[0]);
        (int y1, int y2) = ParsePart(parts[1]);
        (int z1, int z2) = ParsePart(parts[2]);
        return (x1, x2, y1, y2, z1, z2);
    }

    static (int i1, int i2) ParsePart(string part)
    {
        part = part.Substring(2);
        string[] parts = part.Split("..");
        return (parts[0].ToInt(), parts[1].ToInt());
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
