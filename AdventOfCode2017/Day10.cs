using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            foreach (int twist in twists)
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

        public const int LIST_LENGTH = 256;

        public static string PartTwo(string input)
        {
            var twists = new List<int>();
            foreach(char c in input)
            {
                twists.Add(c);
            }
            twists.AddRange(new[] { 17, 31, 73, 47, 23 });

            int[] array = Enumerable.Range(0, LIST_LENGTH).ToArray();
            int pos = 0;
            int skip = 0;
            for (int i = 0; i < 64; i++)
            {
                foreach (int twist in twists)
                {
                    array.ReverseSection(pos, twist);
                    pos += twist + skip++;
                    pos %= LIST_LENGTH;
                }
            }

            int[] dense = DenseHash(array).ToArray();
            return string.Join("", dense.Select(i => i.ToString("x2")));
        }

        // array is 256 long
        static IEnumerable<int> DenseHash(int[] a)
        {
            for(int i = 0; i < LIST_LENGTH; i += 16)
            {
                yield return a[i] ^ a[i + 1] ^ a[i + 2] ^ a[i + 3] ^ a[i + 4] ^ a[i + 5] ^ a[i + 6] ^ a[i + 7] ^ a[i + 8] ^ a[i + 9] ^ a[i + 10] ^ a[i + 11] ^ a[i + 12] ^ a[i + 13] ^ a[i + 14] ^ a[i + 15];
            }
        }
    }
}
