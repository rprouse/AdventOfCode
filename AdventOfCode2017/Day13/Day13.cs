using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day13
    {
        public static int PartOne(string[] input)
        {
            var layers = ParseInput(input);

            int cost = 0;
            for(int i = 0; i <= layers.MaxLayer(); i++)
            {
                var layer = layers.GetLayer(i);
                if(layer != null)
                {
                    cost += layer.Cost();
                }
                layers.Step();
            }
            return cost;
        }

        public static int PartTwo(string[] input)
        {
            return 0;
        }

        static Layer[] ParseInput(IEnumerable<string> input) =>
            input.Where(s => !string.IsNullOrWhiteSpace(s))
                 .Select(s => new Layer(s))
                 .ToArray();

        static int MaxLayer(this IEnumerable<Layer> layers) =>
            layers.Max(l => l.Depth);

        static void Step(this IEnumerable<Layer> layers)
        {
            foreach(var layer in layers)
            {
                layer.Step();
            }
        }

        static Layer GetLayer(this IEnumerable<Layer> layers, int level) =>
            layers.FirstOrDefault(l => l.Depth == level);

        class Layer
        {
            public int Depth { get; }
            public int Range { get; }
            int CurrentRange { get; set; }
            int Direction { get; set; }

            public Layer(string line)
            {
                var split = line.Split(": ");
                int.TryParse(split[0], out int index);
                int.TryParse(split[1], out int value);
                Depth = index;
                Range = value;
            }

            public int Cost() =>
                CurrentRange == 0 ? Depth * Range : 0;

            public void Step()
            {
                if(Range == 1)
                {
                    Direction = 0;
                }
                else if(CurrentRange == 0)
                {
                    Direction = 1;
                }
                else if(CurrentRange == Range - 1)
                {
                    Direction = -1;
                }
                CurrentRange += Direction;
            }
        }
    }
}
