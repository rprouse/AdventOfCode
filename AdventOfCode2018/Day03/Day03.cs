using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public static class Day03
    {
        public class Claim
        {
            static Regex regex = new Regex(@"\#(\d+) @ (\d+),(\d+): (\d+)x(\d+)", RegexOptions.Compiled);

            public int Number { get; }
            public int X { get; }
            public int Y { get; }
            public int W { get; }
            public int H { get; }

            public Claim(string claim)
            {
                var match = regex.Match(claim);
                if (!match.Success) throw new ArgumentException("Invalid claim");

                Number = match.GetInt(1);
                X = match.GetInt(2);
                Y = match.GetInt(3);
                W = match.GetInt(4);
                H = match.GetInt(5);
            }

            public bool Overlaps(int[,] fabric)
            {
                foreach (int y in Enumerable.Range(Y, H))
                {
                    foreach (int x in Enumerable.Range(X, W))
                    {
                        if (fabric[x, y] > 1)
                            return true;
                    }
                }
                return false;
            }
        }

        public static int PartOne(string filename)
        {
            var claims = ParseClaims(filename);
            var fabric = MakeClaims(claims);
            return fabric.Cast<int>().Count(f => f > 1);
        }

        public static int PartTwo(string filename)
        {
            var claims = ParseClaims(filename);
            var fabric = MakeClaims(claims);
            return claims.Where(c => !c.Overlaps(fabric)).Single().Number;
        }

        private static Claim[] ParseClaims(string filename) =>
            filename.ReadAllLines()
                    .Select(l => new Claim(l))
                    .ToArray();

        private static int[,] MakeClaims(Claim[] claims)
        {
            int maxX = claims.Select(c => c.X + c.W).Max();
            int maxY = claims.Select(c => c.Y + c.H).Max();
            int[,] fabric = new int[maxX, maxY];
            foreach (var claim in claims)
            {
                foreach (int y in Enumerable.Range(claim.Y, claim.H))
                {
                    foreach (int x in Enumerable.Range(claim.X, claim.W))
                    {
                        fabric[x, y]++;
                    }
                }
            }
            return fabric;
        }
    }
}
