using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day20
{
    public static int PartOne(string filename, int passes)
    {
        string[] lines = filename.ReadAllLinesIncludingBlank();
        int[] enhance = lines[0].Select(c => c == '#' ? 1 : 0).ToArray();
        int[][] image = lines
            .Skip(2)
            .Select(line => line.Select(c => c == '#' ? 1 : 0).ToArray())
            .ToArray();

        ViewImage(image);

        for (int i = 0; i < passes; i++)
        {
            int[][] newImage = new int[image.Length + 2][];
            for (int y = 0; y < newImage.Length; y++)
            {
                newImage[y] = new int[image[0].Length + 2];
                if ( y > 0 && y < newImage.Length - 1)
                {
                    for(int x = 0; x < image[0].Length; x++)
                    {
                        newImage[y][x + 1] = image[y - 1][x];
                    }
                }
            }
            image = newImage; 
            newImage = new int[image.Length][];
            for (int y = 0; y < newImage.Length; y++)
            {
                newImage[y] = new int[image[y].Length];
                for (int x = 0; x < newImage[y].Length; x++)
                {
                    int index = 0;
                    if (x > 0 && y > 0) index += image[y - 1][x - 1];
                    index = index << 1;
                    if (y > 0) index += image[y - 1][x];
                    index = index << 1;
                    if (x < image[y].Length - 1 && y > 0) index += image[y - 1][x + 1];
                    index = index << 1;
                    if (x > 0) index += image[y][x - 1];
                    index = index << 1;
                    index += image[y][x];
                    index = index << 1;
                    if (x < image[y].Length - 1) index += image[y][x + 1];
                    index = index << 1;
                    if (x > 0 && y < image.Length - 1) index += image[y + 1][x - 1];
                    index = index << 1;
                    if (y < image.Length - 1) index += image[y + 1][x];
                    index = index << 1;
                    if (x < image[y].Length - 1 && y < image.Length - 1) index += image[y + 1][x + 1];

                    newImage[y][x] = enhance[index];
                }
            }
            image = newImage;
            ViewImage(image);
        }

        return image.Sum(l => l.Count(c => c == 1));
    }

    static void ViewImage(int[][] image)
    {
        for (int y = 0; y < image.Length; y++)
        {
            for (int x = 0; x < image[y].Length; x++)
            {
                Console.Write(image[y][x] == 1 ? '#' : '.');
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
