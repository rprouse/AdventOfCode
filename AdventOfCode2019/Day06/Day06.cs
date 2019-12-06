using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day06
    {
        public static int PartOne(string filename)
        {
            var orbits = ReadOrbits(filename.ReadAllLines());
            return CountOrbits(orbits);
        }

        public static int PartTwo(string filename)
        {
            var orbits = ReadOrbits(filename.ReadAllLines());
            return 0;
        }

        public static Dictionary<string, List<string>> ReadOrbits(string[] lines)
        {
            var orbits = new Dictionary<string, List<string>>();

            foreach(var line in lines)
            {
                string[] split = line.Split(')');
                if (orbits.ContainsKey(split[0]))
                    orbits[split[0]].Add(split[1]);
                else
                    orbits.Add(split[0], new List<string>(new[] { split[1] }));
            }
            return orbits;
        }

        public static int CountOrbits(Dictionary<string, List<string>> orbits) =>
            CountOrbits(orbits, "COM", 0);

        public static int CountOrbits(Dictionary<string, List<string>> orbits, string body, int depth)
        {
            int count = depth;

            if (orbits.ContainsKey(body))
            {
                foreach (string child in orbits[body])
                    count += CountOrbits(orbits, child, depth + 1);
            }

            return count;
        }
    }
}
