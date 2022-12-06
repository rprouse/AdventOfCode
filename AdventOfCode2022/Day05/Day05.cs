using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022;

public static class Day05
{
    public static string PartOne(string filename)
    {
        var data = new PuzzleData(filename);

        // Perform moves
        foreach (Move move in data.Moves) 
        {
            foreach (var _ in Enumerable.Range(0, move.BoxesToMove))
            {
                data.Stacks[move.To].Push(data.Stacks[move.From].Pop());
            }
        }

        // Get the top crate from each stack
        return new string(data.Stacks.Select(s => s.Peek()).ToArray());
    }

    public static string PartTwo(string filename)
    {
        var data = new PuzzleData(filename);

        // Perform moves
        var lift = new Stack<char>();
        foreach (var move in data.Moves)
        {
            foreach (var _ in Enumerable.Range(0, move.BoxesToMove))
            {
                lift.Push(data.Stacks[move.From].Pop());
            }
            while(lift.Count > 0)
                data.Stacks[move.To].Push(lift.Pop());
        }

        // Get the top crate from each stack
        return new string(data.Stacks.Select(s => s.Peek()).ToArray());
    } 
}
