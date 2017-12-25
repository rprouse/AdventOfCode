using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day24
    {
        static int maxDepth = 0;
        static int maxStrengthAtDepth = 0;

        public static int PartOne(string filename)
        {
            var parts = GetParts(filename);
            return BuildBridge(parts);
        }

        public static int PartTwo(string filename)
        {
            var parts = GetParts(filename);
            maxDepth = 0;
            maxStrengthAtDepth = 0;
            BuildBridge(parts);
            return maxStrengthAtDepth;
        }

        static int BuildBridge(List<Part> parts, int strength = 0, int depth = 0, int port = 0)
        {
            depth++;
            int maxStrength = strength;
            foreach (var part in parts.Where(p => p.Matches(port)))
            {
                var copy = new List<Part>(parts);
                // Remove part
                copy.Remove(part);
                // Recurse
                var newStrength = BuildBridge(copy, strength + part.P1 + part.P2, depth, part.OtherPort(port));
                if (newStrength > maxStrength)
                    maxStrength = newStrength;
            }
            if(depth > maxDepth)
            {
                maxStrengthAtDepth = maxStrength;
                maxDepth = depth;
            } else if (depth == maxDepth && maxStrength > maxStrengthAtDepth)
            {
                maxStrengthAtDepth = maxStrength;
            }
            return maxStrength;
        }

        static (int strength, int depth) BuildBridge2(List<Part> parts, int strength, int depth, int port)
        {
            int maxDepth = depth++;
            int maxStrength = strength;
            foreach (var part in parts.Where(p => p.Matches(port)))
            {
                var copy = new List<Part>(parts);
                // Remove part
                copy.Remove(part);
                // Recurse
                (var newStrength, var newDepth) = BuildBridge2(copy, strength + part.P1 + part.P2, depth, part.OtherPort(port));
                if (newDepth > maxDepth)
                {
                    maxDepth = newDepth;
                    maxStrength = newStrength;
                }
                else if (newStrength > maxStrength)
                    maxStrength = newStrength;
            }
            return (maxStrength, maxDepth);
        }

        public static List<Part> GetParts(string filename) =>
            File.ReadAllLines(filename)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => new Part(s))
                .ToList();

        public struct Part
        {
            public int P1 { get; }
            public int P2 { get; }

            public Part(string line)
            {
                string[] ports = line.Split('/');
                int p1 = 0;
                int.TryParse(ports[0], out p1);
                P1 = p1;
                int p2 = 0;
                int.TryParse(ports[1], out p2);
                P2 = p2;
            }

            public Part(Part other)
            {
                P1 = other.P1;
                P2 = other.P2;
            }

            public bool Matches(int port) => P1 == port || P2 == port;

            public int OtherPort(int port) => P1 == port ? P2 : P1;

            public override string ToString() => $"{P1}/{P2}";
        }
    }
}
