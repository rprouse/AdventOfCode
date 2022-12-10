using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day10
{
    public static int PartOne(string filename)
    {
        string[] lines = filename.ReadAllLines();
        int cycles = 0;
        int sum = 0;
        int x = 1;
        foreach (string line in lines)
        {
            if (line.StartsWith("noop"))
            {
                cycles++;
                if ((cycles + 20) % 40 == 0)
                {
                    sum += x * cycles;
                }
            }
            else if (line.StartsWith("addx"))
            {
                cycles++;
                if ((cycles + 20) % 40 == 0)
                {
                    sum += x * cycles;
                }
                cycles++;
                if ((cycles + 20) % 40 == 0)
                {
                    sum += x * cycles;
                }
                x += line.Substring(5).ToInt();
            }
            if (cycles >= 220) break;
        }
        return sum;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
