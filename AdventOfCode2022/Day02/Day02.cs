using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day02
{
    public static int PartOne(string filename) =>
        filename.ReadAllLines()
            .Select(l => l.Score())
            .Sum();

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }

    internal static int Score(this string line)
    {
        // A - Rock
        // B - Paper
        // C - Scissors
        line = line.Convert();
        char p1 = line[0];
        char p2 = line[2];

        // Tie
        if (p1 == p2)
            return p2.ChoiceScore() + 3;

        // Win
        if ((p2 == 'A' && p1 == 'C') ||
            (p2 == 'B' && p1 == 'A') ||
            (p2 == 'C' && p1 == 'B'))
            return p2.ChoiceScore() + 6;

        // Loss
        return p2.ChoiceScore();
    }

    internal static int ChoiceScore(this char c) =>
        c - 'A' + 1;

    static string Convert(this string line) =>
        line.Replace('X', 'A')
            .Replace('Y', 'B')
            .Replace('Z', 'C');
}
