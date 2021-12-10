using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day10
{
    static Dictionary<char, char> _matches = new Dictionary<char, char>
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
        { '<', '>' }
    };

    public static long PartOne(string filename)
    {
        long score = 0;
        string[] lines = filename.ReadAllLines();
        foreach (string line in lines)
        {
            var corrupted = GetCorruptedCharacter(line);
            score += GetCorruptedScore(corrupted);
        }
        return score;
    }

    internal static char GetCorruptedCharacter(string line)
    {
        var buffer = new StringBuilder();
        bool foundMatch = false;
        do
        {
            foundMatch = false;
            buffer.Clear();
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (_matches.ContainsKey(line[i]) &&
                   _matches[line[i]] == line[i + 1])
                {
                    foundMatch = true;
                    i += 1;
                }
                else
                {
                    buffer.Append(line[i]);
                }
            }
            line = buffer.ToString();
        }
        while (foundMatch);
        char corrupted = line.FirstOrDefault(c => _matches.Values.Contains(c));
        Console.WriteLine($"{(corrupted == 0 ? ' ' : corrupted)} {line}");
        return corrupted;
    }

    internal static int GetCorruptedScore(char corrupted) =>
        corrupted switch
        {
            ')' => 3,
            ']' => 57,
            '}' => 1197,
            '>' => 25137,
            _ => 0
        };

    public static long PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
