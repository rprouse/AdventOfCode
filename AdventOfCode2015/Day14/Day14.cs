using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015;

public static class Day14
{
    public static int PartOne(string filename) =>
            filename.ReadAllLines()
                .Select(l => new Reindeer(l))
                .Max(r => r.RaceForSeconds(2503));

    public static int PartTwo(string filename)
    {
        var reindeer = filename
            .ReadAllLines()
            .Select(l => new Reindeer(l))
            .ToArray();

        foreach(var r in reindeer)
            r.RaceForSeconds(2503);

        for (int i = 1; i <= 2503; i++)
        {
            Reindeer maxDeer = null;
            int max = int.MinValue;
            foreach(var r in reindeer)
            {
                if (r.Distance[i] > max)
                {
                    maxDeer = r;
                    max = r.Distance[i];
                }
            }
            if (maxDeer != null)
            {
                maxDeer.Points++;
            }
        }

        return reindeer.Max(r => r.Points);
    }

    internal class Reindeer
    {
        public string Name { get; }
        public int Speed { get; }
        public int Fly { get; }
        public int Rest { get; }
        public Dictionary<int, int> Distance { get; } = new Dictionary<int, int>();
        public int Points { get; set; }

        public Reindeer(string line)
        {
            string[] parts = line.Split(' ');
            Name = parts[0];
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
                    for (int i = totalSeconds + 1; i <= sec; i++)
                    {
                        totalDist += Speed;
                        Distance.Add(i, totalDist);
                    }
                    return totalDist;
                }
                for (int i = totalSeconds + 1; i <= totalSeconds + Fly; i++)
                {
                    totalDist += Speed;
                    Distance.Add(i, totalDist);
                }
                totalSeconds += Fly;

                if (totalSeconds + Rest >= sec)
                {
                    for (int i = totalSeconds + 1; i <= sec; i++)
                    {
                        Distance.Add(i, totalDist);
                    }
                    return totalDist;
                }
                for (int i = totalSeconds + 1; i <= totalSeconds + Rest; i++)
                {
                    Distance.Add(i, totalDist);
                }
                totalSeconds += Rest;
            }
        }
    }
}
