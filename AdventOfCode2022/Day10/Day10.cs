using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using NUnit.Framework;

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

    public static string PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        int cycles = 0;
        int x = 1;
        int row = 0;
        int col = 0;
        char[][] screen = new char[6][];
        for (int r = 0; r < screen.Length; r++)
        {
            screen[r] = Enumerable.Range(0, 40).Select(_ => '.').ToArray();
        }
        foreach (string line in lines)
        {
            if (line.StartsWith("noop"))
            {
                row = cycles / 40;
                col = cycles % 40;
                cycles++;
                if (col >= x - 2 && col <= x + 1)
                    screen[row][col] = '#';
            }
            else if (line.StartsWith("addx"))
            {
                row = cycles / 40;
                col = cycles % 40;
                cycles++;
                if (col >= x - 1 && col <= x + 1)
                    screen[row][col] = '#';
                row = cycles / 40;
                col = cycles % 40;
                cycles++;
                if (col >= x - 1 && col <= x + 1)
                    screen[row][col] = '#';
                x += line.Substring(5).ToInt();
            }
        }
        var result = DrawScreen(screen);
        TestContext.WriteLine(result.ToString());
        return result.ToString();
    }

    public static string DrawScreen(char[][] screen)
    {
        var result = new StringBuilder(40 * 6);
        foreach (char[] screenRow in screen)
            result.AppendLine(new string(screenRow));
        return result.ToString();
    }
}
