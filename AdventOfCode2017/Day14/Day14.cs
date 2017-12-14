using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day14
    {
        public static int PartOne(string key) =>
            Enumerable.Range(0, 128)
                .Select(i => CountBits(Day10.PartTwo($"{key}-{i}")))
                .Sum();

        public static int CountBits(string hash)
        {
            byte[] bytes = StringToByteArray(hash);
            return bytes.Sum(b => BitsInByte(b));
        }

        static int BitsInByte(byte b) =>
            Convert.ToString(b, 2).Count(c => c == '1');

        public static byte[] StringToByteArray(string hex) =>
            Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();

            public static int PartTwo(string str)
        {
            return 0;
        }
    }
}
