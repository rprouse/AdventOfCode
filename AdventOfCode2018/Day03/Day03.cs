using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

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
        }

        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
