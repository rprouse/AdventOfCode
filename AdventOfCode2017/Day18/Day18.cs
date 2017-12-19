using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day18
    {
        public static long PartOne(string[] program)
        {
            var zero = new Program(0, program);
            zero.RecvQueue = new Queue<long>();
            zero.Run();
            while (zero.SendQueue.Count() > 1)
                zero.SendQueue.Dequeue();
            return zero.SendQueue.Dequeue();
        }

        public static long PartTwo(string[] program)
        {
            var zero = new Program(0, program);
            var one = new Program(1, program);
            zero.RecvQueue = one.SendQueue;
            one.RecvQueue = zero.SendQueue;
            while(true)
            {
                if (!zero.Run()) break;
                if (!one.Run()) break;
                if (zero.SendQueue.Count == 0 && one.SendQueue.Count == 0) break;
            }
            return one.SendCount;
        }

        public class Program
        {
            long _ptr = 0;
            IDictionary<char, long> _registers = new Dictionary<char, long>();
            string[] _program;

            public int SendCount { get; private set; }

            public Queue<long> SendQueue { get; } = new Queue<long>();
            public Queue<long> RecvQueue { get; set; }

            public Program(int id, string[] program)
            {
                _registers['p'] = id;
                _program = program;
                SendCount = 0;
            }

            /// <summary>
            /// Runs the program until it blocks in a RCV
            /// </summary>
            public bool Run()
            {
                while (_ptr >= 0 && _ptr < _program.Length && ! string.IsNullOrWhiteSpace(_program[_ptr]))
                {
                    var instr = _program[_ptr].Split(' ');
                    char reg = instr[1][0];
                    if (!_registers.ContainsKey(reg))
                        _registers.Add(reg, 0);

                    long val = instr.Length == 3 ? Value(instr[2]) : 0;

                    //Print();

                    switch (instr[0])
                    {
                        case "snd":
                            SendQueue.Enqueue(_registers[reg]);
                            SendCount++;
                            break;
                        case "rcv":
                            if (RecvQueue.Count == 0) return true;
                            _registers[reg] = RecvQueue.Dequeue();
                            break;
                        case "set":
                            _registers[reg] = val;
                            break;
                        case "add":
                            _registers[reg] += val;
                            break;
                        case "mul":
                            _registers[reg] *= val;
                            break;
                        case "mod":
                            _registers[reg] %= val;
                            break;
                        case "jgz":
                            if (Value(instr[1]) > 0)
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
                    _registers.ContainsKey(register[0]))
                {
                    val = _registers[register[0]];
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

                    if (i < _registers.Count)
                    {
                        Console.CursorLeft = 20;
                        Console.Write($"{_registers.Keys.ElementAt(i)}:{_registers.Values.ElementAt(i)}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
