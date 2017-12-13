using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day13
    {
        public static int PartOne(string[] input) =>
            ParseInput(input).Sum(l => l.Cost());

        public static int PartTwo(string[] input)
        {
            return 0;
        }

        static Layer[] ParseInput(IEnumerable<string> input) =>
            input.Where(s => !string.IsNullOrWhiteSpace(s))
                 .Select(s => new Layer(s))
                 .ToArray();

        class Layer
        {
            public int Depth { get; }
            public int Range { get; }

            public Layer(string line)
            {
                var split = line.Split(": ");
                int.TryParse(split[0], out int depth);
                int.TryParse(split[1], out int range);
                Depth = depth;
                Range = range;
            }

            public int Cost() =>
                 Depth % (2 * Range - 2) == 0 ? Depth * Range : 0;
        }
    }
}
