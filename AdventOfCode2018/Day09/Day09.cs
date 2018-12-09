using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day09
    {
        public static long PartOne(int players, int highMarble)
        {
            var circle = new List<int>(highMarble + 1) { 0, 16, 8, 17, 4, 18, 9, 19, 2, 20, 10, 21, 5, 22, 11, 1, 12, 6, 13, 3, 14, 7, 15 };
            var marbles = new List<int>(Enumerable.Range(23, highMarble - 22));
            var elves = new long[players];
            var currentMarble = 13;

            while (marbles.Count > 0)
            {
                // Take the lowest marble
                int marble = marbles.Min();
                marbles.Remove(marble);

                // Play the marble
                if (marble % 23 == 0)
                {
                    var currentElf = circle.Count % players;
                    elves[currentElf] += marble;

                    // Take the marble 7 to the right
                    if (currentMarble > 7)
                        currentMarble = currentMarble - 7;
                    else
                        currentMarble = circle.Count - 7 + currentMarble;
                    elves[currentElf] += circle[currentMarble];
                    circle.RemoveAt(currentMarble);
                }
                else if (currentMarble == circle.Count - 2)
                {
                    currentMarble = circle.Count;
                    circle.Add(marble);
                }
                else
                {
                    currentMarble = (currentMarble + 2) % circle.Count;
                    circle.Insert(currentMarble, marble);
                }
            }
            return elves.Max();
        }

        public static int PartTwo(string filename)
        {
            return 0;
        }
    }
}
