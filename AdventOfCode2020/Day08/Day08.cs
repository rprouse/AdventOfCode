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
            _ = emulator.Run(program);
            return emulator.Accumulator;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            Instruction[] program = filename.ReadAllLines()
                .Select(l => new Instruction(l))
                .ToArray();

            for(int i = 0; i < program.Length; i++)
            {
                if (program[i].Operation == "acc")
                    continue;

                Instruction[] newProgram = program.Select(instr => new Instruction(instr)).ToArray();
                newProgram[i].Operation = program[i].Operation == "nop" ? "jmp" : "nop";

                var emulator = new ConsoleEmulator();
                var result = emulator.Run(newProgram);
                if(result)
                    return emulator.Accumulator;
            }
            return -1;
        }
    }

    public class ConsoleEmulator
    {
        public int Accumulator { get; private set; }

        int _pointer;

        Instruction[] _program;

        public ConsoleEmulator()
        {
        }

        public bool Run(Instruction[] program)
        {
            _program = program;
            List<int> seen = new List<int>();
            while(true)
            {
                if (seen.Contains(_pointer))
                    return false;
                seen.Add(_pointer);

                switch(_program[_pointer].Operation)
                {
                    case "acc":
                        Accumulator += _program[_pointer].Argument;
                        _pointer++;
                        break;
                    case "jmp":
                        _pointer += _program[_pointer].Argument;
                        break;
                    case "nop":
                        _pointer++;
                        break;                    
                }
                if (_pointer >= _program.Length)
                    return true;
            }
        }
    }

    public class Instruction
    {
        public string Operation { get; set; }
        public int Argument { get; set; }

        public Instruction(string instruction)
        {
            string[] parts = instruction.Split(' ');
            Operation = parts[0];
            Argument = parts[1].ToInt();
        }

        public Instruction(Instruction other)
        {
            Operation = other.Operation;
            Argument = other.Argument;
        }

        public override string ToString() => $"{Operation} {Argument}";
    }
}
