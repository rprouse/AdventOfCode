using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day20
{
    public static int Enhance(string filename, int passes)
    { 
        (bool[] algorithm, HashSet<(int x, int y)> image) = ParseInput(filename);

        //ViewImage(image);
        for (int i = 0; i < passes / 2; i++)
        {
            image = Enhance(image, algorithm, true);
            //ViewImage(image);
            image = Enhance(image, algorithm, false);
            //ViewImage(image);
        }
        //ViewImage(image);

        return image.Count;
    }

    static HashSet<(int x, int y)> Enhance(HashSet<(int x, int y)> image, bool[] algorithm, bool first)
    {
        int offset = 2;
        if (algorithm[0]) offset = first ? 3 : -1;
        int minX = image.MinBy(pos => pos.x).x - offset;
        int minY = image.MinBy(pos => pos.y).y - offset;
        int maxX = image.MaxBy(pos => pos.x).x + offset;
        int maxY = image.MaxBy(pos => pos.y).y + offset;

        HashSet<(int x, int y)> enhanced = new HashSet<(int x, int y)>();
        for (int y = minY; y <= maxY; y++)
        {
            for (int x = minX; x <= maxX; x++)
            {
                int enhanceIndex = EnhanceIndex(image, x, y, first);
                if (algorithm[enhanceIndex])
                    enhanced.Add((x, y));
            }
        }
        return enhanced;
    }

    static int EnhanceIndex(HashSet<(int x, int y)> image, int x, int y, bool first)
    {
        int index = 0;

        if (image.Contains((x - 1, y - 1)))
            index++;
        index = index << 1;

        if (image.Contains((x, y - 1)))
            index++;
        index = index << 1;

        if (image.Contains((x + 1, y - 1)))
            index++;
        index = index << 1;

        if (image.Contains((x - 1, y)))
            index++;
        index = index << 1;

        if (image.Contains((x, y)))
            index++;
        index = index << 1;

        if (image.Contains((x + 1, y)))
            index++;
        index = index << 1;

        if (image.Contains((x - 1, y + 1)))
            index++;
        index = index << 1;

        if (image.Contains((x, y + 1)))
            index++;
        index = index << 1;

        if (image.Contains((x + 1, y + 1)))
            index++;

        return index;
    }

    static void ViewImage(HashSet<(int x, int y)> image)
    {
        int maxX = image.MaxBy(pos => pos.x).x;
        int maxY = image.MaxBy(pos => pos.y).y;
        for (int y = image.MinBy(pos => pos.y).y; y <= maxY; y++)
        {
            for (int x = image.MinBy(pos => pos.x).x; x <= maxX; x++)
            {
                Console.Write(image.Contains((x, y)) ? '#' : '.');
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static (bool[] algorithm, HashSet<(int x, int y)> image) ParseInput(string filename)
    {
        string[] lines = filename.ReadAllLinesIncludingBlank();
        bool[] enhance = lines[0].Select(c => c == '#' ? true : false).ToArray();
        var image = lines.Skip(2).Select(line => line).ToArray();
        var set = new HashSet<(int x, int y)>();
        for (int y = 0; y < image.Length; y++)
        {
            for (int x = 0; x < image[0].Length; x++)
            {
                if (image[y][x] == '#')
                    set.Add((x, y));
            }
        }
        return (enhance, set);
    }
}
