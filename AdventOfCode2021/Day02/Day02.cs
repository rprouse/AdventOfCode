using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day02
{
    public static int PartOne(string filename)
    {
        var directions = filename
            .ReadAllLines()
            .Select(line => line.Split())
            .Select(pair => (pair[0], pair[1].ToInt()))
            .ToArray();

        int x = 0;
        int y = 0;
        foreach ((string dir, int dist) in directions)
        {
            switch (dir[0])
            {
                case 'f':
                    x += dist;
                    break;
                case 'd':
                    y += dist;
                    break;
                case 'u':
                    y -= dist;
                    break;
            }
        }
        return x * y;
    }

    public static int PartTwo(string filename)
    {
        var directions = filename
            .ReadAllLines()
            .Select(line => line.Split())
            .Select(pair => (pair[0], pair[1].ToInt()))
            .ToArray();

        int x = 0;
        int y = 0;
        int aim = 0;
        foreach ((string dir, int dist) in directions)
        {
            switch (dir[0])
            {
                case 'f':
                    x += dist;
                    y += aim * dist;
                    break;
                case 'd':
                    aim += dist;
                    break;
                case 'u':
                    aim -= dist;
                    break;
            }
        }
        return x * y;
    }
}
