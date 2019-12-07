using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    public enum ParameterMode
    {
        Position = 0,
        Immediate = 1
    }

    public class IntcodeComputer
    {
        int[] _codes;
        Queue<int> _input;

        public IntcodeComputer(int[] codes, int[] input)
        {
            _codes = (int[])codes.Clone();
            _input = new Queue<int>(input);
        }

        public int RunProgram()
        {
            int output = 0;
            int pc = 0; // Program counter
            while (true)
            {
                int ptr = _codes[pc++];
                int opcode = GetOpCode(ptr);
                var mode1 = GetParameterMode(ptr, 1);
                var mode2 = GetParameterMode(ptr, 2);
                var mode3 = GetParameterMode(ptr, 3);
                switch (opcode)
                {
                    case 1: // Add
                        {
                            int ptrA = _codes[pc++];
                            int ptrB = _codes[pc++];
                            int ptrC = _codes[pc++];
                            _codes[ptrC] = GetValue(ptrA, mode1) + GetValue(ptrB, mode2);
                            break;
                        }
                    case 2: // Multiply
                        {
                            int ptrA = _codes[pc++];
                            int ptrB = _codes[pc++];
                            int ptrC = _codes[pc++];
                            _codes[ptrC] = GetValue(ptrA, mode1) * GetValue(ptrB, mode2);
                            break;
                        }
                    case 3: // Input
                        {
                            int ptrA = _codes[pc++];
                            _codes[ptrA] = _input.Dequeue();
                            break;
                        }
                    case 4: // Output
                        {
                            int ptrA = _codes[pc++];
                            output = GetValue(ptrA, mode1);
                            Console.WriteLine(output);
                            break;
                        }
                    case 5: // Jump if true
                        {
                            int ptrA = _codes[pc++];
                            int ptrB = _codes[pc++];
                            if (GetValue(ptrA, mode1) != 0)
                                pc = GetValue(ptrB, mode2);
                            break;
                        }
                    case 6: // Jump if false
                        {
                            int ptrA = _codes[pc++];
                            int ptrB = _codes[pc++];
                            if (GetValue(ptrA, mode1) == 0)
                                pc = GetValue(ptrB, mode2);
                            break;
                        }
                    case 7: // Less than
                        {
                            int ptrA = _codes[pc++];
                            int ptrB = _codes[pc++];
                            int ptrC = _codes[pc++];
                            _codes[ptrC] = (GetValue(ptrA, mode1) < GetValue(ptrB, mode2)) ? 1 : 0;
                            break;
                        }
                    case 8: // Equals
                        {
                            int ptrA = _codes[pc++];
                            int ptrB = _codes[pc++];
                            int ptrC = _codes[pc++];
                            _codes[ptrC] = (GetValue(ptrA, mode1) == GetValue(ptrB, mode2)) ? 1 : 0;
                            break;
                        }
                    case 99: // Halt
                        return output;
                    default:
                        throw new Exception($"Unknown opcode {opcode} at position {pc}");
                }
            }
        }

        public int GetValue(int ptr, ParameterMode mode) =>
            mode == ParameterMode.Immediate ? ptr : _codes[ptr];

        public static int GetOpCode(int ptr) =>
            ptr % 100;

        public static ParameterMode GetParameterMode(int ptr, int param) =>
            (ParameterMode)DigitAt(ptr, 3 - param);

        public static int DigitAt(int num, int digit)
        {
            for (int i = 0; i < 4 - digit; i++)
                num = num / 10;

            return num % 10;
        }
    }
}
