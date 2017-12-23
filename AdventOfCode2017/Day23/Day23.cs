using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day23
    {
        public static int PartOne(string filename)
        {
            var prog = LoadProgram(filename);
            prog.Run();
            return prog.MulCount;
        }

        static Program LoadProgram(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            return new Program(lines);
        }

        public static long PartTwo(string filename)
        {

            int g = 0, h = 0;
            int b = 106700;
            int c = b + 17000;
            do
            {
                bool f = false; // 9

                // 12
                for (int d = 2; d * d <= b; d++)
                {
                    if (b % d == 0)
                    {
                        f = true;  // Not prime
                        break;
                    }
                }

                // 25
                if (f) h++;

                g = b - c; // 27, 28
                b += 17;   // 31
            }
            while (g != 0);
            return h;
        }

        public class Program
        {
            long _ptr = 0;
            public IDictionary<char, long> Registers { get; } = new Dictionary<char, long>();
            string[] _program;

            public int MulCount { get; private set; }

            public Queue<long> SendQueue { get; } = new Queue<long>();
            public Queue<long> RecvQueue { get; set; }

            public Program(string[] program)
            {
                _program = program;
                MulCount = 0;
            }

            /// <summary>
            /// Runs the program until it blocks in a RCV
            /// </summary>
            public bool Run()
            {
                while (_ptr >= 0 && _ptr < _program.Length && !string.IsNullOrWhiteSpace(_program[_ptr]))
                {
                    var instr = _program[_ptr].Split(' ');
                    char reg = instr[1][0];
                    if (!Registers.ContainsKey(reg))
                        Registers.Add(reg, 0);

                    long val = instr.Length == 3 ? Value(instr[2]) : 0;

                    //Print();

                    switch (instr[0])
                    {
                        case "snd":
                            SendQueue.Enqueue(Registers[reg]);
                            break;
                        case "rcv":
                            if (RecvQueue.Count == 0) return true;
                            Registers[reg] = RecvQueue.Dequeue();
                            break;
                        case "set":
                            Registers[reg] = val;
                            break;
                        case "add":
                            Registers[reg] += val;
                            break;
                        case "sub":
                            Registers[reg] -= val;
                            break;
                        case "mul":
                            Registers[reg] *= val;
                            MulCount++;
                            break;
                        case "mod":
                            Registers[reg] %= val;
                            break;
                        case "jgz":
                            if (Value(instr[1]) > 0)
                            {
                                _ptr += val;
                                continue;
                            }
                            break;
                        case "jnz":
                            if (Value(instr[1]) != 0)
                            {
                                _ptr += val;
                                continue;
                            }
                            break;
                    }
                    _ptr++;
                }
                return false;
            }

            long Value(string register)
            {
                long val = 0;
                if (!long.TryParse(register, out val) &&
                    Registers.ContainsKey(register[0]))
                {
                    val = Registers[register[0]];
                }
                return val;
            }

            void Print()
            {
                Console.Clear();
                for (int i = 0; i < _program.Length; i++)
                {
                    if (_ptr == i) Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(_program[i]);
                    Console.ResetColor();

                    if (i < Registers.Count)
                    {
                        Console.CursorLeft = 20;
                        Console.Write($"{Registers.Keys.ElementAt(i)}:{Registers.Values.ElementAt(i)}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
