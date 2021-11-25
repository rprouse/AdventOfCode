using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015;

public static class Day14
{
    public static int PartOne(string filename) =>
            filename
                .ReadAllLines()
                .Select(l => new Reindeer(l))
                .Max(r => r.RaceForSeconds(2503));

    public static int PartTwo(string filename)
    {
        var reindeer = filename
            .ReadAllLines()
            .Select(l => new Reindeer(l));

        return 0;
    }

    internal class Reindeer
    {
        public int Speed { get; }
        public int Fly { get; }
        public int Rest { get; }

        public Reindeer(string line)
        {
            string[] parts = line.Split(' ');
            Speed = parts[3].ToInt();
            Fly = parts[6].ToInt();
            Rest = parts[13].ToInt();
        }

        public int RaceForSeconds(int sec)
        {
            int totalDist = 0;
            int totalSeconds = 0;
            while (true)
            {
                if (totalSeconds + Fly >= sec)
                {
                    totalDist += (sec - totalSeconds) * Speed;
                    return totalDist;
                }
                totalDist += Fly * Speed;
                totalSeconds += Fly;

                if (totalSeconds + Rest >= sec)
                    return totalDist;
                totalSeconds += Rest;
            }
        }
    }
}
