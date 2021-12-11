#define DISPLAY_FINAL
#undef DISPLAY_ALL

using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Text.RegularExpressions;


namespace AdventOfCode2018
{
    public static class Day17
    {
        public static int PartOne(string filename)
        {
            // Parse the file
            (string a, int v1, int v2, int v3)[] matches = Regex
                .Matches(filename.ReadAll(), @"([xy])=(\d*), ([xy])=(\d*)..(\d*)", RegexOptions.Multiline)
                .Cast<Match>()
                .Select(match => (match.Groups[1].Value, match.GetInt(2), match.GetInt(4), match.GetInt(5)))
                .ToArray();

            // Find bounds
            int maxX1 = matches.Where(m => m.a == "x").Max(m => m.v1);
            int maxX2 = matches.Where(m => m.a == "y").Max(m => m.v3);
            int maxX = Math.Max(maxX1, maxX2);

            int minX1 = matches.Where(m => m.a == "x").Min(m => m.v1);
            int minX2 = matches.Where(m => m.a == "y").Min(m => m.v3);
            int minX = Math.Min(minX1, minX2) - 1;

            int maxY1 = matches.Where(m => m.a == "y").Max(m => m.v1);
            int maxY2 = matches.Where(m => m.a == "x").Max(m => m.v3);
            int maxY = Math.Max(maxY1, maxY2);

            char[,] ground = new char[maxX - minX + 2, maxY + 2];

            // Draw initial ground
            foreach (var m in matches)
            {
                for (int i = m.v2; i <= m.v3; i++)
                {
                    if (m.a == "x")
                        ground[m.v1 - minX, i] = '#';
                    else
                        ground[i - minX, m.v1] = '#';
                }
            }

            // Drip down from the well
            DripDown(ground, 500 - minX, 1);

#if DISPLAY_FINAL
            OutputGround(ground);
            Console.WriteLine("Finished");
#endif

            int water = ground.Cast<char>().Where(c => c == '~').Count();
            int drips = ground.Cast<char>().Where(c => c == '|').Count();

            Console.WriteLine($"Water: {water}, Drips: {drips}, Total: {water + drips}");
            return water + drips;
        }

        static void DripDown(char[,] ground, int x, int y)
        {
            ground[x, y] = '|';

            while (ground[x, y + 1] != '#' && ground[x, y + 1] != '~')
            {
                y++;
                if (y >= ground.GetLength(1) - 1)
                    return;
                ground[x, y] = '|';
            }

#if DISPLAY_ALL
            OutputGround(ground);
            Console.ReadLine();
#endif

            do
            {
                bool dripRight = false;
                bool dripLeft = false;
                int minX;
                for (minX = x; minX >= 0; minX--)
                {
                    if (!ground.Occupied(minX, y + 1))
                    {
                        dripLeft = true;
                        break;
                    }
                    ground[minX, y] = '|';
                    if (ground.Occupied(minX - 1, y))
                        break;
                }

                int maxX;
                for (maxX = x; maxX < ground.GetLength(0); maxX++)
                {
                    if (!ground.Occupied(maxX, y + 1))
                    {
                        dripRight = true;
                        break;
                    }
                    ground[maxX, y] = '|';
                    if (ground.Occupied(maxX + 1, y))
                        break;
                }
                if (dripRight && ground[maxX, y + 1] != '|')
                    DripDown(ground, maxX, y);

                if (dripLeft && ground[minX, y + 1] != '|')
                    DripDown(ground, minX, y);

                if (dripLeft || dripRight)
                    return;

                for (int i = minX; i < maxX + 1; i++)
                {
                    ground[i, y] = '~';
                }

                y--;

#if DISPLAY_ALL
                OutputGround(ground);
                Console.ReadLine();
#endif
            } while (true);
        }

        static bool Occupied(this char[,] ground, int x, int y) =>
            x < 0 || x >= ground.GetLength(0) || ground[x, y] == '#' || ground[x, y] == '~';

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        static void OutputGround(char[,] ground)
        {
            Console.Clear();
            var sb = new StringBuilder(ground.GetLength(0));
            for (int y = 0; y < ground.GetLength(1); y++)
            {
                sb.Clear();
                for (int x = 0; x < ground.GetLength(0); x++)
                {
                    sb.Append(ground[x, y] == '\0' ? '.' : ground[x, y]);
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
