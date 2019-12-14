using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Threading.Tasks;

namespace AdventOfCode2019
{

    public static class Day13
    {
        public static int PartOne(string filename)
        {
            long[] program = filename.SplitLongs();
            var game = new ArcadeCabinet(program);
            game.RunProgram();

            int count = 0;
            foreach(long pixel in game.Screen)
            {
                if (pixel == 2) count++;
            }
            return count;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
