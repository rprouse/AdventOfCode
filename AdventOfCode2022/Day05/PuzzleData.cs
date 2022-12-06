using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

internal class PuzzleData
{
    public Stack<char>[] Stacks { get; private set; }
    public IEnumerable<Move> Moves { get; private set; }

    int _numStacks = 0;
    int _bottom = 0;

    public PuzzleData(string filename)
    {
        string[] lines = filename.ReadAllLines();

        // Figure out where the _bottom of the stacks are
        FindNumberOfStacks(lines);

        // Build the stacks
        Stacks = BuildStacks(lines);

        // Get the moves 
        Moves = lines.Skip(_bottom + 1).Select(l => new Move(l));
    }

    private void FindNumberOfStacks(string[] lines)
    {
        for (; _bottom < lines.Length; _bottom++)
        {
            if (lines[_bottom][1] == '1')
            {
                _numStacks = (lines[_bottom].Length + 1) / 4;
                break;
            }
        }
    }

    private Stack<char>[] BuildStacks(string[] lines)
    {
        Stack<char>[] stacks = new Stack<char>[_numStacks];
        for (int level = _bottom - 1; level >= 0; level--)
        {
            for (int stackNumber = 0; stackNumber < _numStacks; stackNumber++)
            {
                if (level == _bottom - 1) stacks[stackNumber] = new Stack<char>();

                char c = CharAtStack(lines[level], stackNumber);
                if (c != ' ') stacks[stackNumber].Push(c);
            }
        }
        return stacks;
    }

    public static char CharAtStack(string line, int stackNumber) =>
        line[stackNumber * 4 + 1];
}
