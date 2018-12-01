using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using AdventOfCode2016.DayEleven;

namespace AdventOfCode2016
{
    public class Day11
    {
        public static int PartOne(Floors floors)
        {
            return floors.Solve();
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
