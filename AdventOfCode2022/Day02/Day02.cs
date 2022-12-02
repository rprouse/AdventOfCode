using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using NUnit.Framework.Constraints;

namespace AdventOfCode2022;

public static class Day02
{
    public static int PartOne(string filename) =>
        filename.ReadAllLines()
            .Select(l => l.ScorePartOne())
            .Sum();

    public static int PartTwo(string filename) =>
        filename.ReadAllLines()
            .Select(l => l.ScorePartTwo())
            .Sum();

    internal static int ScorePartOne(this string line)
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

    internal static int ScorePartTwo(this string line)
    {
        // A - Rock / Lose
        // B - Paper / Draw
        // C - Scissors / Win
        line = line.Convert();
        char p1 = line[0];
        char p2 = line[2];

        switch (p2)
        {
            case 'A': // Loss
                switch(p1)
                {
                    case 'A':
                        return 'C'.ChoiceScore();
                    case 'B':
                        return 'A'.ChoiceScore();
                    case 'C':
                    default:
                        return 'B'.ChoiceScore();
                }

            case 'B': // Tie
                return p1.ChoiceScore() + 3;

            case 'C': // Win
            default:
                switch (p1)
                {
                    case 'A':
                        return 'B'.ChoiceScore() + 6;
                    case 'B':
                        return 'C'.ChoiceScore() + 6;
                    case 'C':
                    default:
                        return 'A'.ChoiceScore() + 6;
                }
        }
    }

    internal static int ChoiceScore(this char c) =>
        c - 'A' + 1;

    static string Convert(this string line) =>
        line.Replace('X', 'A')
            .Replace('Y', 'B')
            .Replace('Z', 'C');
}
