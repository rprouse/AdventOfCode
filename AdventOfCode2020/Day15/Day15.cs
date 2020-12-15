using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day15
    {
        public static int PartOne(int[] numbers)
        {
            int[] spoken = new int[2020];
            Array.Copy(numbers, spoken, numbers.Length);

            for(int i = numbers.Length; i < 2019; i++)
            {
                int lastSpoken = WasSpoken(spoken, i);
                if(lastSpoken != -1)
                {
                    spoken[i + 1] = i - lastSpoken;
                }
            }
            return spoken[2019];    // zero based
        }

        // Returns the index where the number at index was last spoken or -1 if it wasn't spoken
        static int WasSpoken(int[] spoken, int index)
        {
            for (int i = index - 1; i >= 0; i--)
                if (spoken[i] == spoken[index])
                    return i;
            return -1;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
