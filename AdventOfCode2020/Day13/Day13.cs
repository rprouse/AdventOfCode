using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day13
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            int time = lines[0].ToInt();
            var busses = lines[1].Split(',').Where(s => s != "x").Select(s => s.ToInt()).ToArray();
            for (int i = time; ; i++)
            {
                foreach (var bus in busses)
                {
                    if (i % bus == 0) return (i - time) * bus;
                }
            }
        }

        public static long PartTwo(string filename) =>
            FirstCommonTime(filename.ReadAllLines()[1]);

        internal static long FirstCommonTime(string line)
        {
            var busses = line.Split(',').Select(s => s.ToLong()).ToArray();

            long inc = busses[0];
            int common = 1;
            for (long i = inc; ; i += inc)
            {
                while (busses[common] == 0) // never ends in an x
                    common++;

                if ((i + common) % busses[common] == 0)
                {
                    common++;
                    inc = busses.Take(common).Where(b => b != 0).Aggregate(1L, (a, b) => a * b);
                }

                if (common == busses.Length)
                    return i;
            }
        }
    }
}
