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

        public static long PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return FirstCommonTime(lines[1]);
        }

        internal static long FirstCommonTime(string line)
        {
            var busses = line.Split(',').Select(s => s.ToInt()).ToArray();
            int max = busses.Max();
            int maxPos = Enumerable.Range(0, busses.Length).Where(i => busses[i] == max).First();

            for (long i = max - maxPos; ; i += max)
            {
                bool invalid = false;
                for (int j = 0; j < busses.Length; j++)
                {
                    if (busses[j] == 0) continue;
                    if ((i + j) % busses[j] != 0)
                    {
                        invalid = true;
                        break;
                    }
                }
                if (!invalid)
                    return i;
            }
        }
    }
}
