using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

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

    // A - Rock, B - Paper, C - Scissors
    static Dictionary<char, char> _wins = new Dictionary<char, char>
    {
        { 'A', 'C' }, { 'B', 'A' }, { 'C', 'B' }
    };

    internal static (char p1, char p2) ParseLine(this string line)
    {
        line = line.Convert();
        return (line[0], line[2]);
    }

    internal static int ScorePartOne(this string line)
    {
        (char p1, char p2) = line.ParseLine();

        // Draw
        if (p1 == p2)
            return p2.ChoiceScore() + 3;

        // Win
        if (_wins[p2] == p1)
            return p2.ChoiceScore() + 6;

        // Loss
        return p2.ChoiceScore();
    }

    internal static int ScorePartTwo(this string line)
    {
        (char p1, char p2) = line.ParseLine();

        return p2 switch
        {
            'A' => _wins[p1].ChoiceScore(), // A - I Lose
            'B' => p1.ChoiceScore() + 3,    // B - I Draw
            'C' => _wins                    // C - I Win
                    .Where(p => p.Value == p1)
                    .Select(p => p.Key)
                    .First()
                    .ChoiceScore() + 6,
            _ => throw new NotSupportedException($"{line} unrecognized")
        }; ;
    }

    internal static int ChoiceScore(this char c) =>
        c - 'A' + 1;

    static string Convert(this string line) =>
        line.Replace('X', 'A')
            .Replace('Y', 'B')
            .Replace('Z', 'C');
}
