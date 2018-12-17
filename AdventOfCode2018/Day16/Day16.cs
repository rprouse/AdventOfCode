using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Core;
using AdventOfCode2018.DaySixteen;

namespace AdventOfCode2018
{
    public static class Day16
    {
        static Regex regex = new Regex(@".+\[(\d*), (\d*), (\d*), (\d*)\]", RegexOptions.Compiled);

        public static int PartOne(string filename)
        {
            int[,] pos = new int[16, 16]; // Opcode matches

            string[] lines = filename.ReadAllLines(); // Strips out empty lines
            int count = 0;
            var computer = new Computer();

            for(int i = 0; i < lines.Length - 2; i += 3)
            {
                (int a1, int b1, int c1, int d1) = ParseRegisterState(lines[i]);
                (int o, int a, int b, int c) = ParseOperation(lines[i+1]);
                (int a2, int b2, int c2, int d2) = ParseRegisterState(lines[i+2]);
                int matches = 0;
                for(int o1 = 0; o1 < 16; o1++)
                {
                    computer.SetRegisters(a1, b1, c1, d1);
                    int[] result = computer.Opcodes[o1](a, b, c);
                    if(result[0] == a2 && result[1] == b2 && result[2] == c2 && result[3] == d2)
                    {
                        matches++;
                        pos[o, o1]++;
                    }
                }
                if (matches >= 3) count++;
            }
            OutputMatches(pos);
            return count;
        }

        static void OutputMatches(int[,] pos)
        {
            Console.WriteLine("     00 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15");
            Console.WriteLine("----------------------------------------------------");
            for (int y = 0; y < 16; y++)
            {
                Console.Write($"{y:00} | ");
                for (int x = 0; x < 16; x++)
                {
                    if (pos[x, y] == 0)
                        Console.Write("   ");
                    else
                        Console.Write($"{pos[x, y]:00} ");
                }
                Console.WriteLine();
            }
        }

        public static (int a, int b, int c, int d) ParseRegisterState(string line)
        {
            var match = regex.Match(line);
            if (!match.Success)
                throw new ArgumentException($"Line {line} is in an unknown format");

            return (match.GetInt(1), match.GetInt(2), match.GetInt(3), match.GetInt(4));
        }

        public static (int o, int a, int b, int c) ParseOperation(string line)
        {
            string[] parts = line.Split(' ');
            if(parts.Length != 4)
                throw new ArgumentException($"Line {line} is in an unknown format");

            return (parts[0].ToInt(), parts[1].ToInt(), parts[2].ToInt(), parts[3].ToInt());
        }

        public static int PartTwo(string filename)
        {
            var computer = new Computer();
            filename.ReadAllLines()
                .Select(l => ParseOperation(l))
                .ForEach(o => computer.ExecuteOperation(o.o, o.a, o.b, o.c));
            return computer.Registers[0];
        }
    }
}
