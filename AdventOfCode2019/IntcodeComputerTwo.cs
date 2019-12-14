using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public class IntcodeComputerTwo
    {
        const int MEMORY = 128 * 1024;  // 128K
        long[] _memory;
        long _relativeBase = 0;
        long _pc = 0; // Program counter
        bool _halted = false;
        long _output = 0;

        public event EventHandler<EventArgs> OutputAvailable;

        public IntcodeComputerTwo(long[] program)
        {
            _memory = new long[MEMORY];
            for (int i = 0; i < program.Length; i++)
                _memory[i] = program[i];
        }

        public IntcodeComputerTwo(long[] program, long[] input) :
            this(program)
        {
            foreach (int i in input)
                Input.Enqueue(i);
        }

        public Queue<long> Input { get; set; } = new Queue<long>();
        public Queue<long> Output { get; set; } = new Queue<long>();

        public async Task<long> RunProgram()
        {
            _output = 0;
            _halted = false;
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
                            SetValue(ptrC, modeC, GetValue(ptrA, modeA) + GetValue(ptrB, modeB));
                            break;
                        }
                    case 2: // Multiply
                        {
                            long ptrA = _memory[_pc++];
                            long ptrB = _memory[_pc++];
                            long ptrC = _memory[_pc++];
                            SetValue(ptrC, modeC, GetValue(ptrA, modeA) * GetValue(ptrB, modeB));
                            break;
                        }
                    case 3: // Input
                        {
                            long ptrA = _memory[_pc++];
                            // Wait for input
                            while (Input.Count == 0)
                                await Task.Delay(10);
                            SetValue(ptrA, modeA, Input.Dequeue());
                            break;
                        }
                    case 4: // Output
                        {
                            long ptrA = _memory[_pc++];
                            _output = GetValue(ptrA, modeA);
                            Output.Enqueue(_output);
                            Console.WriteLine(_output);
                            OutputAvailable?.Invoke(this, EventArgs.Empty);
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
                            SetValue(ptrC, modeC, (GetValue(ptrA, modeA) < GetValue(ptrB, modeB)) ? 1 : 0);
                            break;
                        }
                    case 8: // Equals
                        {
                            long ptrA = _memory[_pc++];
                            long ptrB = _memory[_pc++];
                            long ptrC = _memory[_pc++];
                            SetValue(ptrC, modeC, (GetValue(ptrA, modeA) == GetValue(ptrB, modeB)) ? 1 : 0);
                            break;
                        }
                    case 9: // Relative Base
                        {
                            long ptrA = _memory[_pc++];
                            _relativeBase += GetValue(ptrA, modeA);
                            break;
                        }
                    case 99: // Halt
                        _halted = true;
                        Output.Enqueue(_output); // Put it on again so we don't block in day 11
                        return _output;
                    default:
                        throw new Exception($"Unknown opcode {opcode} at position {_pc}");
                }
            }
        }

        public async Task<long> GetOutput()
        {
            long o;
            while (!Output.TryDequeue(out o))
            {
                if (_halted) return 0;
                await Task.Delay(10);
            }
            return _halted ? _output : o;
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

        public void SetValue(long ptr, ParameterMode mode, long value)
        {
            switch (mode)
            {
                case ParameterMode.Position:
                    _memory[ptr] = value;
                    break;
                case ParameterMode.Relative:
                    _memory[_relativeBase + ptr] = value;
                    break;
                case ParameterMode.Immediate:
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
