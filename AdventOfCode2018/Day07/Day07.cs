using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day07
    {
        public class Step
        {
            public Step(char name)
            {
                Name = name;
            }

            public char Name { get; set; }

            public Dictionary<char, Step> Next { get; } = new Dictionary<char, Step>();
            public Dictionary<char, Step> Prev { get; } = new Dictionary<char, Step>();
        }

        public static string PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();

            // Build the tree
            var steps = BuildTree(lines);

            // Find the first steps
            return new string(WalkTree(steps).ToArray());
        }

        private static Dictionary<char, Step> BuildTree(string[] lines)
        {
            var steps = new Dictionary<char, Step>();
            foreach (string line in lines)
            {
                char s = line[5];   // Step name
                char n = line[36];  // Next step
                if (!steps.ContainsKey(s))
                    steps.Add(s, new Step(s));

                if (!steps.ContainsKey(n))
                    steps.Add(n, new Step(n));

                var step = steps[s];
                var next = steps[n];
                step.Next.Add(n, next);
                next.Prev.Add(s, step);
            }
            return steps;
        }

        private static IEnumerable<char> WalkTree(Dictionary<char, Step> steps)
        {
            while (steps.Count > 0)
            {
                // Find the steps that have no predecessors and take lowest alphabetically
                char firstKey = steps.Values.Where(s => s.Prev.Count == 0)
                    .Select(s => s.Name)
                    .Min();

                Step first = steps[firstKey];

                // Remove the first from the tree
                steps.Remove(firstKey);
                foreach(var next in first.Next.Values)
                {
                    next.Prev.Remove(firstKey);
                }
                yield return firstKey;
            }
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
