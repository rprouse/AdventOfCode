using System.Collections.Generic;
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
            return DistanceToSanta(orbits);
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

        public static int DistanceToSanta(Dictionary<string, List<string>> orbits)
        {
            int count = 0;

            List<string> myOrbits = WalkToRootBody(orbits, "YOU", new List<string>());
            List<string> santasOrbits = WalkToRootBody(orbits, "SAN", new List<string>());

            string nearest = string.Empty;
            foreach(string body in myOrbits)
            {
                count++;
                if(santasOrbits.Contains(body))
                {
                    nearest = body;
                    break;
                }
            }

            foreach(string body in santasOrbits)
            {
                count++;
                if (body == nearest)
                    break;
            }

            return count - 2;
        }

        public static string FindBodySateliteIsOrbiting(Dictionary<string, List<string>> orbits, string satellite)
        {
            foreach(string body in orbits.Keys)
            {
                if (orbits[body].Contains(satellite))
                    return body;
            }
            return string.Empty;
        }

        public static List<string> WalkToRootBody(Dictionary<string, List<string>> orbits, string satellite, List<string> list)
        {
            string body = FindBodySateliteIsOrbiting(orbits, satellite);
            if(body != "COM")
            {
                list.Add(body);
                WalkToRootBody(orbits, body, list);
            }
            return list;
        }
    }
}
