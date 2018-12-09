using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Day09
    {
        public static long PartOne(int players, int highMarble)
        {
            var circle = new LinkedList<int>();
            var elves = new long[players];
            var current = circle.AddFirst(0);

            for (int marble = 1; marble <= highMarble; marble++)
            {
                // Play the marble
                if (marble % 23 == 0)
                {
                    // Take the marble 7 to the right
                    foreach(int i in Enumerable.Range(0, 7))
                        current = current.Previous ?? circle.Last;

                    var currentElf = (marble - 1) % players;
                    elves[currentElf] += marble + current.Value;

                    var tmp = current;
                    current = current.Next ?? circle.First;
                    circle.Remove(tmp);
                }
                else
                {
                    current = current.Next ?? circle.First;
                    current = circle.AddAfter(current, marble);
                }
            }
            return elves.Max();
        }
    }
}
