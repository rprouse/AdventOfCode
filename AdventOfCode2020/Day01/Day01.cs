using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day01
    {
        public static int PartOne(string filename)
        {
            int[] lines = filename.ReadAllLines().Select(s => s.ToInt()).ToArray();
            return TwoThatSum(lines);
        }

        public static int TwoThatSum(int[] values)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                if (values[i] > 2020) continue;
                for (int j = i + 1; j < values.Length; j++)
                {
                    if (values[i] + values[j] == 2020)
                        return values[i] * values[j];
                }
            }
            return 0;
        }

        public static int PartTwo(string filename)
        {
            int[] lines = filename.ReadAllLines().Select(s => s.ToInt()).ToArray();
            return ThreeThatSum(lines);
        }

        public static int ThreeThatSum(int[] values)
        {
            for(int i = 0; i < values.Length - 2; i++)
            {
                if (values[i] > 2020) continue;
                for (int j = i + 1; j < values.Length - 1; j++)
                {
                    if (values[i] + values[j] > 2020) continue;
                    for (int k = j + 1; k < values.Length; k++)
                    {
                        if (values[i] + values[j] + values[k] == 2020)
                            return values[i] * values[j] * values[k];
                    }
                }
            }
            return 0;
        }
    }
}
