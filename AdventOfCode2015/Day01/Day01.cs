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
            return FirstBasementDirection(directions);
        }

        public static int CalculateFloor(string directions) =>
            directions.Count(u => u == '(') - directions.Count(d => d == ')');

        public static int FirstBasementDirection(string directions)
        {
            int floor = 0;
            for(int i = 0; i < directions.Length; i++)
            {
                floor += directions[i] == '(' ? 1 : -1;
                if (floor < 0)
                    return i + 1;
            }
            return 0;
        }
    }
}
