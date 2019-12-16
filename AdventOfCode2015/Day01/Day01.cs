using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day01
    {
        public static int PartOne(string filename)
        {
            string directions = filename.ReadAll();
            return CalculateFloor(directions);
        }

        public static int PartTwo(string filename)
        {
            string directions = filename.ReadAll();
            return 0;
        }

        public static int CalculateFloor(string directions) =>
            directions.Count(u => u == '(') - directions.Count(d => d == ')');
    }
}
