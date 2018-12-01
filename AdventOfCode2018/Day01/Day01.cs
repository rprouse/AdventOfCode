using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day01
    {
        public static int PartOne(string filename) =>
            filename.ReadAllLines()
                .Select(l => l.ToInt())
                .Sum();

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            var found = new List<int>();
            var freq = 0;
            while(true)
            {
                foreach(int i in lines.Select(l => l.ToInt()))
                {
                    freq += i;
                    if (found.Contains(freq))
                        return freq;
                    found.Add(freq);
                }
            }
        }
    }
}
