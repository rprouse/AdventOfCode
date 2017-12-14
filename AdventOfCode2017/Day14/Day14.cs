using System;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day14
    {
        public static int PartOne(string key) =>
            Enumerable.Range(0, 128)
                .Select(i => CountBits(Day10.PartTwo($"{key}-{i}")))
                .Sum();

        public static int CountBits(string hash) =>
            StringToByteArray(hash).Sum(b => BitsInByte(b));

        static int BitsInByte(byte b) =>
            Convert.ToString(b, 2).Count(c => c == '1');

        public static byte[] StringToByteArray(string hex) =>
            Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();

        public static int PartTwo(string key)
        {
            var grid = Enumerable.Range(0, 128)
                   .Select(i => ConvertToBoolArray(
                       StringToByteArray(Day10.PartTwo($"{key}-{i}"))))
                    .ToArray();

            return CountGroups(grid);
        }

        static int CountGroups(bool[][] grid)
        {
            int count = 0;
            for (int x = 0; x < 128; x++)
                for (int y = 0; y < 128; y++)
                {
                    if (grid[x][y])
                    {
                        count++;
                        ClearGroup(grid, x, y);
                    }
                }
            return count;
        }

        static void ClearGroup(bool[][] grid, int x, int y)
        {
            if (x < 0 || y < 0 || x > 127 || y > 127 || !grid[x][y])
                return;

            grid[x][y] = false;
            ClearGroup(grid, x-1, y);
            ClearGroup(grid, x+1, y);
            ClearGroup(grid, x, y-1);
            ClearGroup(grid, x, y+1);
        }

        static bool[] ConvertToBoolArray(byte[] bytes)
        {
            var b = new bool[bytes.Length * 8];
            for (int i = 0; i < bytes.Length; i++)
            {
                string s = Convert.ToString(bytes[i], 2).PadLeft(8, '0');
                for (int j = 0; j < s.Length; j++)
                    if (s[j] == '1') b[i * 8 + j] = true;
            }
            return b;
        }
    }
}
