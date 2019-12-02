using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day01
    {
        public static int PartOne(string filename)
        {
            int[] masses = filename.GetInts();
            return masses.Select(m => FuelRequired(m)).Sum();
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        public static int FuelRequired(int mass) =>
            mass / 3 - 2;
    }
}
