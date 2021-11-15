using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day06
    {
        public static int PartOne(string filename)
        {
            var grid = new LightGrid();
            string[] lines = filename.ReadAllLines();
            foreach (string line in lines)
                grid.ExecuteInstruction(line);
            return grid.NumberLightsOn;
        }

        public static int PartTwo(string filename)
        {
            var grid = new DimableLightGrid();
            string[] lines = filename.ReadAllLines();
            foreach (string line in lines)
                grid.ExecuteInstruction(line);
            return grid.TotalBrightness;
        }

        public class LightGrid
        {
            private bool[,] _grid = new bool[1000, 1000];
            public static Regex regex = new Regex(
                    "(turn on|turn off|toggle)\\s(\\d+),(\\d+)\\sthrough\\s(\\d+),(\\d+)",
                    RegexOptions.CultureInvariant | RegexOptions.Compiled
                );

            public int NumberLightsOn =>
                Enumerable.Range(0, 1000)
                    .Sum(x => Enumerable.Range(0, 1000).Count(y => _grid[x, y]));

            public void ExecuteInstruction(string instruction)
            {
                Match match = regex.Match(instruction);
                if (!match.Success) throw new ArgumentException($"Invalid instruction {instruction}");

                var command = match.Groups[1].Value;
                var x1 = match.Groups[2].Value.ToInt();
                var y1 = match.Groups[3].Value.ToInt();
                var x2 = match.Groups[4].Value.ToInt();
                var y2 = match.Groups[5].Value.ToInt();

                bool newVal = command == "turn on";
                bool toggle = command == "toggle";

                for (int y = y1; y <= y2; y++)
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        if (toggle)
                            _grid[x, y] = !_grid[x, y];
                        else
                            _grid[x, y] = newVal;
                    }
                }
            }
        }

        public class DimableLightGrid
        {
            private int[,] _grid = new int[1000, 1000];
            public static Regex regex = new Regex(
                    "(turn on|turn off|toggle)\\s(\\d+),(\\d+)\\sthrough\\s(\\d+),(\\d+)",
                    RegexOptions.CultureInvariant | RegexOptions.Compiled
                );

            public int TotalBrightness =>
                Enumerable.Range(0, 1000)
                    .Sum(x => Enumerable.Range(0, 1000).Sum(y => _grid[x, y]));

            public void ExecuteInstruction(string instruction)
            {
                Match match = regex.Match(instruction);
                if (!match.Success) throw new ArgumentException($"Invalid instruction {instruction}");

                var command = match.Groups[1].Value;
                var x1 = match.Groups[2].Value.ToInt();
                var y1 = match.Groups[3].Value.ToInt();
                var x2 = match.Groups[4].Value.ToInt();
                var y2 = match.Groups[5].Value.ToInt();

                int change;
                switch (command)
                {
                    case "turn on":
                        change = 1;
                        break;
                    case "turn off":
                        change = -1;
                        break;
                    case "toggle":
                        change = 2;
                        break;
                    default:
                        throw new ArgumentException(nameof(command));
                }

                for (int y = y1; y <= y2; y++)
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        _grid[x, y] += change;
                        if (_grid[x, y] < 0) _grid[x, y] = 0;
                    }
                }
            }
        }
    }
}
