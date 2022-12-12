using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day11
{
    public static ulong CalculateMonkeyBusiness(string filename, int rounds, bool divideByThree)
    {
        Monkey[] monkeys = ParseMonkeys(filename).ToArray();
        uint leastCommonMultiple = LeastCommonMultiple(monkeys.Select(m => m.Divisible));
        for (int round = 0; round < rounds; round++)
        {
            foreach (var monkey in monkeys)
                monkey.ProcessRound(monkeys, divideByThree, leastCommonMultiple);
        }
        var mostActive = monkeys
            .OrderByDescending(m => m.Inspected)
            .Select(m => m.Inspected)
            .Take(2)
            .ToArray();

        return mostActive[0] * mostActive[1];
    }

    public static IEnumerable<Monkey> ParseMonkeys(string filename)
    {
        string[] lines = filename.ReadAllLines();
        for (int i = 0; i < lines.Length;)
        {
            var monkey = new Monkey
            {
                Number = lines[i++].Substring(7, 1).ToInt(),
                Items = new Queue<ulong>(lines[i++].Substring(18).Split(", ").Select(s => (ulong)s.ToInt())),
                OperationStr = lines[i++].Substring(23),
                Divisible = (uint)lines[i++].Substring(21).ToInt(),
                TruePass = lines[i++].Substring(29).ToInt(),
                FalsePass = lines[i++].Substring(30).ToInt()
            };

            // Generate the action
            if (monkey.OperationStr == "* old")
                monkey.Operation = (i) => i * i;
            else if (monkey.OperationStr[0] == '*')
            {
                monkey.Operand = (uint)monkey.OperationStr.Substring(2).ToInt();
                monkey.Operation = (i) => i * monkey.Operand;
            }
            else if (monkey.OperationStr[0] == '+')
            {
                monkey.Operand = (uint)monkey.OperationStr.Substring(2).ToInt();
                monkey.Operation = (i) => i + monkey.Operand;
            }
            else
                throw new InvalidOperationException($"Invalid operation {monkey.OperationStr}");

            yield return monkey;
        }
    }

    public static uint LeastCommonMultiple(IEnumerable<uint> values)
    {
        uint[] sorted = values.OrderByDescending(v => v).ToArray();
        uint multiple = 1;
        while (true)
        {
            uint canditate = sorted[0] * multiple++;
            bool allMultiples = true;
            for (int i = 1; i < sorted.Length; i++)
            {
                if (canditate % sorted[i] != 0)
                {
                    allMultiples = false;
                    break;
                }
            }
            if (allMultiples) return canditate;
        }
    }
}

public class Monkey
{
    public int Number { get; set; }

    public Queue<ulong> Items { get; set; }

    public uint Divisible { get; set; }

    public int TruePass { get; set; }

    public int FalsePass { get; set; }

    public string OperationStr { get; set; }

    public uint Operand { get; set; }

    public Func<ulong, ulong> Operation { get; set; }

    public ulong Inspected { get; set; }

    public void ProcessRound(Monkey[] monkeys, bool divideByThree, uint leastCommonMultiple)
    {
        while (Items.TryDequeue(out ulong worry))
        {
            Inspected++;
            worry = Operation(worry);
            if (divideByThree)
                worry /= 3;
            else 
                worry = worry % leastCommonMultiple;

            if (worry % Divisible == 0)
                monkeys[TruePass].Items.Enqueue(worry);
            else
                monkeys[FalsePass].Items.Enqueue(worry);
        }
    }
}
