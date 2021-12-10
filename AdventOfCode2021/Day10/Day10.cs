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
        { ')', '(' },
        { ']', '[' },
        { '}', '{' },
        { '>', '<' }
    };

    public static long PartOne(string filename)
    {
        long score = 0;
        string[] lines = filename.ReadAllLines();
        foreach (string line in lines)
        {
            var corrupted = GetCorruptedCharacter2(line);
            score += GetCorruptedScore(corrupted);
        }
        return score;
    }

    internal static char GetCorruptedCharacter2(string line)
    {
        var seen = new Stack<char>();
        foreach(char c in line)
        {
            if(!_matches.ContainsKey(c))
                seen.Push(c);
            else if (seen.Peek() == _matches[c])
                seen.Pop();
            else
                return c;
        }
        return '\0';
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
