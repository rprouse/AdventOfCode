using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public enum ParameterMode
    {
        Position = 0,
        Immediate = 1,
        Relative = 2
    }

    public class IntcodeComputer
    {
        const int MEMORY = 128 * 1024;  // 128K
        long[] _memory;
        long _relativeBase = 0;
        long _pc = 0; // Program counter

        public IntcodeComputer(int[] program)
        {
            _memory = new long[MEMORY];
            for (int i = 0; i < program.Length; i++)
                _memory[i] = program[i];
        }

        public IntcodeComputer(int[] program, int[] input) :
            this(program)
        {
            foreach (int i in input)
                Input.Enqueue(i);
        }

        public Queue<long> Input { get; set; } = new Queue<long>();
        public Queue<long> Output { get; set; } = new Queue<long>();

        public async Task<long> RunProgram()
        {
            long output = 0;
            while (true)
            {
                long ptr = _memory[_pc++];
                int opcode = GetOpCode(ptr);
                var modeA = GetParameterMode(ptr, 1);
                var modeB = GetParameterMode(ptr, 2);
                var modeC = GetParameterMode(ptr, 3);
                switch (opcode)
                {
                    case 1: // Add
                        {
                            long ptrA = _memory[_pc++];
                            long ptrB = _memory[_pc++];
                            long ptrC = _memory[_pc++];
                            _memory[ptrC] = GetValue(ptrA, modeA) + GetValue(ptrB, modeB);
                            break;
                        }
                    case 2: // Multiply
                        {
                            long ptrA = _memory[_pc++];
                            long ptrB = _memory[_pc++];
                            long ptrC = _memory[_pc++];
                            _memory[ptrC] = GetValue(ptrA, modeA) * GetValue(ptrB, modeB);
                            break;
                        }
                    case 3: // Input
                        {
                            long ptrA = _memory[_pc++];
                            // Wait for input
                            while (Input.Count == 0)
                                await Task.Delay(10);
                            _memory[ptrA] = Input.Dequeue();
                            break;
                        }
                    case 4: // Output
                        {
                            long ptrA = _memory[_pc++];
                            output = GetValue(ptrA, modeA);
                            Output.Enqueue(output);
                            Console.WriteLine(output);
                            break;
                        }
                    case 5: // Jump if true
                        {
                            long ptrA = _memory[_pc++];
                            long ptrB = _memory[_pc++];
                            if (GetValue(ptrA, modeA) != 0)
                                _pc = GetValue(ptrB, modeB);
                            break;
                        }
                    case 6: // Jump if false
                        {
                            long ptrA = _memory[_pc++];
                            long ptrB = _memory[_pc++];
                            if (GetValue(ptrA, modeA) == 0)
                                _pc = GetValue(ptrB, modeB);
                            break;
                        }
                    case 7: // Less than
                        {
                            long ptrA = _memory[_pc++];
                            long ptrB = _memory[_pc++];
                            long ptrC = _memory[_pc++];
                            _memory[ptrC] = (GetValue(ptrA, modeA) < GetValue(ptrB, modeB)) ? 1 : 0;
                            break;
                        }
                    case 8: // Equals
                        {
                            long ptrA = _memory[_pc++];
                            long ptrB = _memory[_pc++];
                            long ptrC = _memory[_pc++];
                            _memory[ptrC] = (GetValue(ptrA, modeA) == GetValue(ptrB, modeB)) ? 1 : 0;
                            break;
                        }
                    case 9: // Relative Base
                        {
                            long ptrA = _memory[_pc++];
                            _relativeBase += GetValue(ptrA, modeA);
                            break;
                        }
                    case 99: // Halt
                        return output;
                    default:
                        throw new Exception($"Unknown opcode {opcode} at position {_pc}");
                }
            }
        }

        public long GetValue(long ptr, ParameterMode mode)
        {
            switch (mode)
            {
                case ParameterMode.Position:
                    return _memory[ptr];
                case ParameterMode.Immediate:
                    return ptr;
                case ParameterMode.Relative:
                    return _memory[_relativeBase + ptr];
                default:
                    throw new ArgumentException($"Unknown parameter mode {mode}");
            }
        }

        public static int GetOpCode(long ptr) =>
            (int)(ptr % 100);

        public static ParameterMode GetParameterMode(long ptr, int param) =>
            (ParameterMode)DigitAt(ptr, 3 - param);

        public static long DigitAt(long num, int digit)
        {
            for (int i = 0; i < 4 - digit; i++)
                num = num / 10;

            return num % 10;
        }
    }
}
