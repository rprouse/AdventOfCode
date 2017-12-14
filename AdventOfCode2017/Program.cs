using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public static class ProgramEntry
    {
        public static async Task Main()
        {
            await PartTwo("hwlqcszp");

            Console.ResetColor();
            Console.ReadLine();
        }

        public static async Task PartTwo(string key)
        {
            var grid = Enumerable.Range(0, 128)
                   .Select(i => ConvertToBoolArray(
                       StringToByteArray(Day10.PartTwo($"{key}-{i}"))))
                    .ToArray();
            
            Console.Title = "Day 10 Visualization";
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.BackgroundColor = grid[x][y] ? ConsoleColor.White : ConsoleColor.Blue;
                    Console.Write(" ");
                }
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            await ClearGroups(grid);
        }

        static async Task ClearGroups(bool[][] grid)
        {
            for (int y = 0; y < 128; y++)
                for (int x = 0; x < 128; x++)
                {
                    if (grid[x][y])
                    {
                        await ClearGroup(grid, x, y);
                    }
                }
        }

        static async Task ClearGroup(bool[][] grid, int x, int y)
        {
            if (x < 0 || y < 0 || x > 127 || y > 127 || !grid[x][y])
                return;

            grid[x][y] = false;
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            await Task.Delay(1);
            await ClearGroup(grid, x - 1, y);
            await ClearGroup(grid, x + 1, y);
            await ClearGroup(grid, x, y - 1);
            await ClearGroup(grid, x, y + 1);
        }

        public static byte[] StringToByteArray(string hex) =>
            Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();

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
