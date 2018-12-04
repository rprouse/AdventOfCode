using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day04
    {        
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            List<Shift> shifts = new List<Shift>();
            for(int i = 0; i < lines.Length; )
            {
                var shift = new Shift();
                i = shift.Parse(lines, i);
                shifts.Add(shift);
            }
            // Guard with most time awake
            var guards = shifts.GroupBy(s => s.Guard);
            var hours = guards.Select(g => new { Guard = g.Key, Hours = g.Sum(g1 => g1.MinutesAsleep) });
            var max = hours.Max(h => h.Hours);
            var guard = hours.Where(h => h.Hours == max).Select(h => h.Guard).First();

            int[] m = new int[60];
            foreach(var s in shifts.Where(s => s.Guard == guard))
            {
                for (int i = 0; i < 60; i++ )
                {
                    if (s.Asleep[i])
                        m[i]++;
                }
            }
            int maxI = 0;
            for (int i = 1; i < 60; i++)
            {
                if (m[i] > m[maxI])
                    maxI = i;
            }
            return guard * maxI;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        public class Shift
        {
            public DateTime Date { get; private set; }

            public int Guard { get; private set; }

            public bool[] Asleep { get; } = new bool[60];

            public int MinutesAsleep => Asleep.Count(m => m);

            public int Parse(string[] lines, int i)
            {
                Date = GetDateTime(lines[i]);
                Guard = GetGuard(lines[i]);
                while(++i < lines.Length && lines[i][19] != 'G')
                {
                    DateTime asleep = GetDateTime(lines[i++]);
                    DateTime awake = GetDateTime(lines[i]);
                    for (int m = asleep.Minute; m < awake.Minute; m++)
                        Asleep[m] = true;
                }
                return i;
            }

            internal static DateTime GetDateTime(string line)
            {
                if (!DateTime.TryParse(line.Substring(1, 16), out DateTime dt))
                    throw new ArgumentException($"Invalid DateTime in {line}");
                return dt;
            }

            static Regex _guard = new Regex(@"Guard #(\d+) begins shift", RegexOptions.Compiled);
            internal static int GetGuard(string line) =>
                _guard.Match(line).GetInt(1);
        }
    }
}
