using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day10
    {
        public static int TwistMultiplier(int length, IEnumerable<int> twists)
        {
            int[] array = Twist(length, twists);
            return array[0] * array[1];
        }

        public static int[] Twist(int length, IEnumerable<int> twists)
        {
            int[] array = Enumerable.Range(0, length).ToArray();
            int pos = 0;
            int skip = 0;
            foreach(int twist in twists)
            {
                array.ReverseSection(pos, twist);
                pos += twist + skip++;
                pos %= length;
            }
            return array;
        }

        public static int[] ReverseSection(this int[] array, int start, int length)
        {
            int[] copy = new int[length];
            for(int i = 0; i < length; i++)
            {
                copy[i] = array[(start + i) % array.Length];
            }
            copy = copy.Reverse().ToArray();
            for (int i = 0; i < length; i++)
            {
                array[(start + i) % array.Length] = copy[i];
            }
            return array;
        }
    }
}
