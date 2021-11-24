using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day14
    {
        public static int PartOne(string filename) =>
            filename.ReadAllLines()
                .Max(x => RaceForSeconds(x,2503));

        internal static int RaceForSeconds(string text, int sec)
        {
            string[] parts = text.Split(' ');
            int speed = parts[3].ToInt();
            int fly = parts[6].ToInt();
            int rest = parts[13].ToInt();

            int totalDist = 0;
            int totalSeconds = 0;
            while(true)
            {
                if (totalSeconds + fly >= sec)
                {
                    totalDist += (sec - totalSeconds) * speed;
                    return totalDist;
                }
                totalDist += fly * speed;
                totalSeconds += fly;

                if (totalSeconds + rest >= sec)
                    return totalDist;
                totalSeconds += rest;
            }
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
