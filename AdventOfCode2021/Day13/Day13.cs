using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day13
{
    public static int PartOne(string filename)
    {
        (List<Point> paper, List<string> folds) = ParseInput(filename);
        //ViewPaper(paper);
        paper = Fold(paper, folds.First());
        //ViewPaper(paper);
        return paper.Count;
    }

    private static (List<Point> paper, List<string> folds) ParseInput(string filename)
    {
        string[] lines = filename.ReadAllLinesIncludingBlank();
        var paper = new List<Point>();
        var folds = new List<string>();
        bool blankFound = false;
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                blankFound = true;
                continue;
            }
            if (blankFound)
            {
                folds.Add(line);
            }
            else
            {
                var parts = line.Split(',');
                paper.Add(new Point(parts[0].ToInt(), parts[1].ToInt()));
            }
        }
        return (paper, folds);
    }

    public static int PartTwo(string filename)
    {
        (List<Point> paper, List<string> folds) = ParseInput(filename);
        //ViewPaper(paper);
        foreach (var fold in folds)
        {
            paper = Fold(paper, fold);
            //ViewPaper(paper);
        }
        ViewPaper(paper);
        return 0;
    }

    internal static List<Point> Fold(List<Point> paper, string fold) =>
        fold[11] == 'y' ?
        FoldY(paper, GetFoldLine(fold)) :
        FoldX(paper, GetFoldLine(fold));

    internal static List<Point> FoldX(List<Point> paper, int fold)
    {
        var left = paper.Where(p => p.X < fold);
        var folded = new List<Point>(left);
        var right = paper
            .Where(p => p.X > fold)
            .Select(p => new Point(2 * fold - p.X, p.Y))
            .Where(p => !folded.Contains(p))
            .ToList();
        folded.AddRange(right);
        return folded;
    }

    internal static List<Point> FoldY(List<Point> paper, int fold)
    {
        var top = paper.Where(p => p.Y < fold);
        var folded = new List<Point>(top);
        var bottom = paper
            .Where(p => p.Y > fold)
            .Select(p => new Point(p.X, 2 * fold - p.Y))
            .Where(p => !folded.Contains(p))
            .ToList();
        folded.AddRange(bottom);
        return folded;
    }

    internal static int GetFoldLine(string fold) =>
        fold.Substring(13).ToInt();

    internal static void ViewPaper(List<Point> paper)
    {
        for (int y = 0; y <= paper.Max(p => p.Y); y++)
        {
            for (int x = 0; x <= paper.Max(p => p.X); x++)
            {
                char c = paper.Contains(new Point(x, y)) ?
                    '#' : '.';
                Console.Write(c);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
