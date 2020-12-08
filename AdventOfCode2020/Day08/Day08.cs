using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day08
    {
        public static int PartOne(string filename)
        {
            Instruction[] program = filename.ReadAllLines()
                .Select(l => new Instruction(l))
                .ToArray();
            var emulator = new ConsoleEmulator();
            return emulator.Run(program);
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }

    public class ConsoleEmulator
    {
        int _accumulator;
        int _pointer;

        Instruction[] _program;

        public ConsoleEmulator()
        {
        }

        public int Run(Instruction[] program)
        {
            _program = program;
            List<int> seen = new List<int>();
            while(true)
            {
                if (seen.Contains(_pointer))
                    return _accumulator;
                seen.Add(_pointer);

                switch(_program[_pointer].Operation)
                {
                    case "acc":
                        _accumulator += _program[_pointer].Argument;
                        _pointer++;
                        break;
                    case "jmp":
                        _pointer += _program[_pointer].Argument;
                        break;
                    case "nop":
                        _pointer++;
                        break;                    
                }
            }
            return _accumulator;
        }
    }

    public class Instruction
    {
        public string Operation { get; }
        public int Argument { get; }

        public Instruction(string instruction)
        {
            string[] parts = instruction.Split(' ');
            Operation = parts[0];
            Argument = parts[1].ToInt();
        }
    }
}
