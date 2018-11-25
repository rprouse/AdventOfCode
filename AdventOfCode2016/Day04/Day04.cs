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
            return RealRooms(filename).Sum(r => r.Sector);
        }

        public static int PartTwo(string filename)
        {
            return RealRooms(filename).Where(r => r.Name.Contains("north")).Select(r => r.Sector).FirstOrDefault();
        }

        static IEnumerable<Day04> RealRooms(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return lines.Select(l => new Day04(l)).Where(r => r.RealRoom);
        }

        int _sector;

        public string Encrypted { get; }
        public string Name { get; }
        public int Sector => _sector;
        public string Checksum { get; }
        public bool RealRoom { get; }

        public Day04(string code)
        {
            Encrypted = code.Substring(0, code.Length - 11);
            Checksum = code.Substring(code.Length - 6, 5);
            string sector = code.Substring(code.Length - 10, 3);
            int.TryParse(sector, out _sector);

            RealRoom = Checksum == CalculateChecksum(Encrypted);
            Name = Decrypt(Encrypted, Sector);
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

        internal static string Decrypt(string encrypted, int sector)
        {
            // char 'a' is 97
            var decrypted = new char[encrypted.Length];
            for(int i = 0; i < encrypted.Length; i++)
            {
                if (encrypted[i] == '-')
                    decrypted[i] = ' ';
                else
                {
                    decrypted[i] = (char)(((encrypted[i] - 96 + sector) % 26) + 96);
                }
            }
            return new string(decrypted);
        }
    }
}
