using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Text.RegularExpressions;

namespace AdventOfCode2022;

public static class Day05
{
    public static Regex regex = new Regex(
      "move (\\d+) from (\\d+) to (\\d+)",
       RegexOptions.CultureInvariant | RegexOptions.Compiled
    );

    public static string PartOne(string filename)
    {
        string[] lines = filename.ReadAllLines();

        // Figure out where the bottom of the stacks are
        int bottom = 0;
        int numStacks = 0;
        for (; bottom < lines.Length; bottom++)
        {
            if (lines[bottom][1] == '1')
            {
                numStacks = (lines[bottom].Length + 1) / 4;
                break;
            }
        }

        // Build the stacks
        Stack<char>[] stacks = new Stack<char>[numStacks];
        for (int level = bottom - 1; level >= 0; level--)
        {
            for (int stackNumber = 0; stackNumber < numStacks; stackNumber++)
            {
                if (level == bottom - 1) stacks[stackNumber] = new Stack<char>();

                char c = CharAtStack(lines[level], stackNumber);
                if (c != ' ') stacks[stackNumber].Push(c);
            }
        }

        // Perform moves
        foreach(string moveStr in lines.Skip(bottom + 1)) 
        {
            Match match = regex.Match(moveStr);
            int numMoves = match.Groups[1].Value.ToInt();
            int from = match.Groups[2].Value.ToInt();
            int to = match.Groups[3].Value.ToInt();

            for(int move = 0; move < numMoves; move++)
            {
                stacks[to-1].Push(stacks[from-1].Pop());
            }
        }

        // Get the top crate from each stack
        return new string(stacks.Select(s => s.Peek()).ToArray());
    }

    public static char CharAtStack(string line, int stackNumber) =>
        line[stackNumber * 4 + 1];

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
