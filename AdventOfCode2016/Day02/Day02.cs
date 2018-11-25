using System;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public static class Day02
    {
        static string keys = "123456789ABCD";

        public static string PartOne(string filename) =>
            Solve(filename, Move1);

        public static string PartTwo(string filename) =>
            Solve(filename, Move2);

        private static string Solve(string filename, Func<char, int, int> move)
        {
            string[] lines = filename.ReadAllLines();
            var sb = new StringBuilder(lines.Length);
            int key = 5;

            foreach (string line in lines)
            {
                foreach (char m in line)
                {
                    key = move(m, key);
                }
                sb.Append(keys[key-1]);
            }
            return sb.ToString();
        }

        static int Move1(char m, int key)
        {
            switch (m)
            {
                case 'U':
                    if (key > 3)
                        key -= 3;
                    break;
                case 'D':
                    if (key < 7)
                        key += 3;
                    break;
                case 'R':
                    if (key % 3 != 0)
                        key++;
                    break;
                case 'L':
                    if (key % 3 != 1)
                        key--;
                    break;
            }
            return key;
        }

        static int Move2(char m, int key)
        {
            switch (m)
            {
                case 'U':
                    if (key == 3)
                        key = 1;
                    else if (key == 6)
                        key = 2;
                    else if (key == 7)
                        key = 3;
                    else if (key == 8)
                        key = 4;
                    else if (key == 0xA)
                        key = 6;
                    else if (key == 0xB)
                        key = 7;
                    else if (key == 0xC)
                        key = 8;
                    else if (key == 0xD)
                        key = 0xB;
                    break;
                case 'D':
                    if (key == 1)
                        key = 3;
                    else if (key == 2)
                        key = 6;
                    else if (key == 3)
                        key = 7;
                    else if (key == 4)
                        key = 8;
                    else if (key == 6)
                        key = 0xA;
                    else if (key == 7)
                        key = 0xB;
                    else if (key == 8)
                        key = 0xC;
                    else if (key == 0xB)
                        key = 0xD;
                    break;
                case 'R':
                    if (key == 2 ||
                        key == 3 ||
                        (key >= 5 && key <= 8) ||
                        key == 0xA ||
                        key == 0xB)
                        key++;
                    break;
                case 'L':
                    if (key == 3 ||
                        key == 4 ||
                        (key >= 6 && key <= 9) ||
                        key == 0xB ||
                        key == 0xC)
                        key--;
                    break;
            }
            return key;
        }
    }
}
