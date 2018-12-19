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

            char[,] ground = new char[maxX - minX + 2, maxY + 1];

            // Draw initial ground
            foreach(var m in matches)
            {
                for(int i = m.v2; i <= m.v3; i++)
                {
                    if (m.a == "x")
                        ground[m.v1 - minX, i] = '#';
                    else
                        ground[i - minX, m.v1] = '#';
                }
            }

            // Drip down from the well
            int x = 500 - minX;
            int y = 1;
            DripDown(ground, x, y);

            OutputGround(ground);
            Console.WriteLine("Finished");

            return ground.Cast<char>().Where(c => c == '|' || c == '~').Count();
        }

        static void DripDown(char[,] ground, int x, int y)
        {
            while (y < ground.GetLength(1) && ground[x, y] == '\0')
            {
                ground[x, y] = '|';
                y++;
            }
            if (y == ground.GetLength(1)) return;
            //OutputGround(ground);
            while (Fill(ground, x, --y))
            {
            }
        }

        static bool Fill(char[,] ground, int x, int y)
        {
            //if (y < 0)
                //return false;

            ground[x, y] = '~';

            // Fill to the left
            bool dripped = false;
            int l = x - 1;
            while(l > 0 && (ground[l, y] == '\0' || ground[l, y] == '|'))
            {
                ground[l, y] = '~';
                //if (ground[l, y + 1] == '|')
                //    break;
                if(ground[l, y + 1] == '\0')
                {
                    dripped = true;
                    DripDown(ground, l, y + 1);
                    break;
                }
                l--;
            }
            //OutputGround(ground);

            // Fill to the right
            int r = x + 1;
            while (r < ground.GetLength(0) && (ground[r, y] == '\0' || ground[r, y] == '|'))
            {
                ground[r, y] = '~';
                //if (ground[r, y + 1] == '|')
                //    break;
                if (ground[r, y + 1] == '\0')
                {
                    dripped = true;
                    DripDown(ground, r, y + 1);
                    break;
                }
                r++;
            }
            //OutputGround(ground);

            return !dripped;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        static void OutputGround(char[,] ground)
        {
#if true
            Console.Clear();
            var sb = new StringBuilder(ground.GetLength(0));
            for(int y = 0; y < ground.GetLength(1) && y < 60; y++)
            {
                sb.Clear();
                for (int x = 0; x < ground.GetLength(0); x++)
                {
                    sb.Append(ground[x, y] == '\0' ? '.' : ground[x, y]);
                }
                Console.WriteLine(sb.ToString());
            }
            Console.ReadLine();
#endif
        }
    }
}
