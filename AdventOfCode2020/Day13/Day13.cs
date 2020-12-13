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
            for(int i = time; ; i++)
            {
                foreach(var bus in busses)
                {
                    if(i % bus == 0) return (i - time) * bus;
                }
            }
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
