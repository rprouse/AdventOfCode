using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public class Day04
    {
        public static int PartOne(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            return lines.Select(l => new Day04(l)).Where(r => r.RealRoom).Sum(r => r.Sector);
        }

        public static int PartTwo(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            return 0;
        }

        int _sector;

        public string Name { get; }
        public int Sector => _sector;
        public string Checksum { get; }
        public bool RealRoom { get; }

        public Day04(string code)
        {
            Name = code.Substring(0, code.Length - 11);
            Checksum = code.Substring(code.Length - 6, 5);
            string sector = code.Substring(code.Length - 10, 3);
            int.TryParse(sector, out _sector);

            RealRoom = Checksum == CalculateChecksum(Name);
        }

        internal static string CalculateChecksum(string name)
        {
            var chars = name.Replace("-", "").ToCharArray();
            Array.Sort(chars);
            var counts = new Dictionary<char, int>();
            foreach(char c in chars)
            {
                if (!counts.ContainsKey(c))
                    counts[c] = 1;
                else
                    counts[c]++;
            }
            char[] r = new char[5];
            for(int i = 0; i < 5; i++)
            {
                char maxc = '0';
                int maxv = -1;
                foreach(char c in counts.Keys)
                {
                    if(counts[c] > maxv)
                    {
                        maxc = c;
                        maxv = counts[c];
                    }
                }
                r[i] = maxc;
                counts[maxc] = 0;
            }
            return new string(r);
        }
    }
}
