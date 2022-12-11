using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Linq.Expressions;

namespace AdventOfCode2022;

public static class Day11
{
    public static int PartOne(string filename)
    {
        Monkey[] monkeys = ParseMonkeys(filename).ToArray();
        for (int round = 0; round < 20; round++)
        {
            foreach (var monkey in monkeys)
                monkey.ProcessRound(monkeys);
        }
        var mostActive = monkeys
            .OrderByDescending(m => m.Inspected)
            .Select(m => m.Inspected)
            .Take(2)
            .ToArray();

        return mostActive[0] * mostActive[1];
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }

    public static IEnumerable<Monkey> ParseMonkeys(string filename)
    {
        string[] lines = filename.ReadAllLines();
        for (int i = 0; i < lines.Length;)
        {
            var monkey = new Monkey
            {
                Number = lines[i++].Substring(7, 1).ToInt(),
                Items = new Queue<int>(lines[i++].Substring(18).Split(", ").Select(s => s.ToInt())), // Reverse?
                OperationStr = lines[i++].Substring(23),
                Divisible = lines[i++].Substring(21).ToInt(),
                TruePass = lines[i++].Substring(29).ToInt(),
                FalsePass = lines[i++].Substring(30).ToInt()
            };

            // Generate the action
            if (monkey.OperationStr == "* old")
                monkey.Operation = (i) => i * i;
            else if (monkey.OperationStr[0] == '*')
                monkey.Operation = (i) => i * monkey.OperationStr.Substring(2).ToInt();
            else if (monkey.OperationStr[0] == '+')
                monkey.Operation = (i) => i + monkey.OperationStr.Substring(2).ToInt();
            else
                throw new InvalidOperationException($"Invalid operation {monkey.OperationStr}");

            yield return monkey;
        }
    }
}

public class Monkey
{
    public int Number { get; set; }

    public Queue<int> Items { get; set; }

    public int Divisible { get; set; }

    public int TruePass { get; set; }

    public int FalsePass { get; set; }

    public string OperationStr { get; set; }

    public Func<int, int> Operation { get; set; }

    public int Inspected { get; set; }

    public void ProcessRound(Monkey[] monkeys)
    {
        while (Items.TryDequeue(out int worry))
        {
            Inspected++;
            worry = Operation(worry) / 3;
            if (worry % Divisible == 0)
                monkeys[TruePass].Items.Enqueue(worry);
            else
                monkeys[FalsePass].Items.Enqueue(worry);
        }
    }
}
