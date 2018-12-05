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
            return RemovePairs(line.ToArray());
        }

        public static int PartTwo(string filename)
        {
            string line = filename.ReadFirstLine();
            int min = int.MaxValue;
            foreach(char c in line.ToLower().Distinct())
            {
                char[] cleaned = line.Where(l => c != char.ToLower(l)).ToArray();
                int reacted = RemovePairs(cleaned);
                if (reacted < min)
                    min = reacted;
            }
            return min;
        }

        internal static int RemovePairs(char[] polymer)
        {
            for (int i = 0; i < polymer.Length - 1; i++)
            {
                int j = i + 1;
                while(polymer[j] == ' ')
                {
                    j++;
                    if (j > polymer.Length - 1)
                        break;
                }

                if (j > polymer.Length - 1)
                    break;

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
            return polymer.Count(c => c != ' ');
        }

        internal static bool IsPair(char a, char b) =>
            a != b && char.ToUpper(a) == char.ToUpper(b);
    }
}
