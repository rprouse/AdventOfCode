using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day05
    {
        public static int PartOne(string filename)
        {
            string line = filename.ReadFirstLine();
            return RemovePairs(line).Length;
        }

        public static int PartTwo(string filename)
        {
            string line = filename.ReadFirstLine();
            return 0;
        }

        internal static string RemovePairs(string line)
        {
            char[] polymer = line.ToArray();
            for (int i = 0; i < polymer.Length - 1; i++)
            {
                int j = i + 1;
                while(polymer[j] == ' ')
                {
                    j++;
                    if (j > polymer.Length - 1)
                        break;
                }
                if (IsPair(polymer[i], polymer[j]))
                {
                    polymer[i] = ' ';
                    polymer[j] = ' ';

                    // Walk back to prevent rescans
                    while(i > 0)
                    {
                        if (polymer[i--] != ' ')
                            break;
                    }
                }
            }
            return new string(polymer.Where(c => c != ' ').ToArray());
        }

        internal static bool IsPair(char a, char b) =>
            a != b && char.ToUpper(a) == char.ToUpper(b);
    }
}
