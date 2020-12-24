using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day23
    {
        const int LEN = 9;

        public static string PartOne(string cupsStr, int moves, bool output = false)
        {
            var cups = cupsStr.Select(c => c.ToString().ToInt() - 1).ToArray();
            var newCups = new int[LEN];
            foreach(int move in Enumerable.Range(0, moves))
            {
                int cup = Wrap(move);

                if (output)
                {
                    var b = new StringBuilder();
                    b.AppendLine($"-- move {move + 1} --");
                    b.Append("cups: ");
                    for (int i = 0; i < LEN; i++)
                    {
                        bool current = cup == i;
                        if (current)
                            b.Append($"({cups[i] + 1}) ");
                        else
                            b.Append($"{cups[i] + 1} ");
                    }
                    b.AppendLine();
                    b.Append($"pick up: {cups[Wrap(cup + 1)] + 1}, {cups[Wrap(cup + 2)] + 1}, {cups[Wrap(cup + 3)] + 1}");
                    Console.WriteLine(b.ToString());
                }

                // Find the destination
                int dest = Wrap(cups[cup] - 1);
                while (dest == cups[Wrap(cup + 1)] || dest == cups[Wrap(cup + 2)] || dest == cups[Wrap(cup + 3)])
                    dest = Wrap(dest - 1);

                // Where is the destination cup?
                int d = IndexOfCup(cups, dest);

                // Copy the current cup
                newCups[cup] = cups[cup];

                // Copy the remaining cups across
                bool placingPickup = false;
                int pickup = cup + 1;
                int remaining = cup + 4;
                for (int c = cup + 1; c < cup + LEN; c++)
                {
                    if(placingPickup)
                    {
                        newCups[Wrap(c)] = cups[Wrap(pickup++)];
                        if (pickup == cup + 4) placingPickup = false;
                        continue;
                    }
                    if (cups[Wrap(remaining)] == dest)
                        placingPickup = true;
                    newCups[Wrap(c)] = cups[Wrap(remaining++)];
                }

                if (output)
                {
                    Console.WriteLine($"destination: {dest + 1}");
                    Console.WriteLine();
                }

                (cups, newCups) = (newCups, cups);
            }
            // Start at cup 1
            var result = new StringBuilder(LEN - 1);
            var one = IndexOfCup(cups, 0);

            for (int c = one + 1; c < one + LEN; c++)
            {
                result.Append(cups[Wrap(c)] + 1);
            }
            return result.ToString();
        }

        internal static int IndexOfCup(int[] cups, int cup)
        {
            for (int i = 0; i < LEN; i++)
                if (cups[i] == cup) return i;
            return -1;
        }

        internal static int Wrap(int cup)
        {
            while (cup < 0) 
                cup += LEN;
            return cup % LEN;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
