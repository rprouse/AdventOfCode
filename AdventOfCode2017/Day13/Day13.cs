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
            var layers = ParseInput(input);
            int delay = 0;
            while(true)
            {
                if (Clear(layers, delay++))
                    return delay - 1;
            }
        }

        static bool Clear(Layer[] layers, int delay) =>
            Enumerable.Range(0, 100)
                .All(depth => layers.IsLayerOpen(delay, depth));

        private static bool IsLayerOpen(this Layer[] layers, int delay, int depth)
        {
            var layer = layers.GetLayer(depth);
            return layer == null || layer.Open(delay + depth);
        }

        static Layer GetLayer(this Layer[] layers, int depth) =>
            layers.FirstOrDefault(l => l.Depth == depth);

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

            public int Cost() => !OpenAtDepth(Depth) ? Depth * Range : 0;

            public bool Open(int delay) => OpenAtDepth(delay);

            private bool OpenAtDepth(int depth) => depth % (2 * (Range - 1)) != 0;
        }
    }
}
