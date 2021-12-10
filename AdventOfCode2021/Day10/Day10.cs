using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    static Dictionary<char, char> _revMatches = new Dictionary<char, char>
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
        var seen = new Stack<char>();
        foreach (char c in line)
        {
            if (!_matches.ContainsKey(c))
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
        var scores = new List<long>();
        string[] lines = filename.ReadAllLines();
        foreach (string line in lines)
        {
            string completion = GetCompletion(line);
            if (completion != null)
            {
                scores.Add(GetCompletionScore(completion));
            }
        }
        scores.Sort();
        return scores.Skip(scores.Count / 2).First();
    }

    internal static string GetCompletion(string line)
    {
        var seen = new Stack<char>();
        foreach (char c in line)
        {
            if (!_matches.ContainsKey(c))
                seen.Push(c);
            else if (seen.Peek() == _matches[c])
                seen.Pop();
            else
                return null;
        }
        var builder = new StringBuilder(seen.Count);
        while (seen.Count > 0)
        {
            builder.Append(_revMatches[seen.Pop()]);
        }
        return builder.ToString();
    }

    internal static long GetCompletionScore(string completion)
    {
        long score = 0;
        foreach (char c in completion)
        {
            int val = c switch
            {
                ')' => 1,
                ']' => 2,
                '}' => 3,
                '>' => 4,
                _ => throw new NotImplementedException()
            };
            score = score * 5 + val;
        }
        return score;
    }
}
