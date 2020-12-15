using System.Collections.Generic;

namespace AdventOfCode2020
{
    public static class Day15
    {
        public static int LastSpoken(int[] numbers, int stop)
        {
            Dictionary<int, int> spoken = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length - 1; i++)
                spoken[numbers[i]] = i + 1;
            int lastSpoken = numbers[^1];

            for (int i = numbers.Length; i < stop; i++)
            {
                int previous = WasSpoken(spoken, lastSpoken);
                spoken[lastSpoken] = i;
                lastSpoken = (previous != -1) ? i - previous : 0;
            }
            return lastSpoken;
        }

        // Returns the turn where the number was last spoken or -1 if it wasn't spoken
        static int WasSpoken(Dictionary<int, int> spoken, int lastSpoken)
        {
            if (spoken.TryGetValue(lastSpoken, out int previous))
                return previous;
            return -1;
        }
    }
}
