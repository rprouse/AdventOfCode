using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public enum ParameterMode
    {
        Position = 0,
        Immediate = 1
    }

    public static class Day05
    {
        public static int PartOne(string filename)
        {
            int[] codes = filename.SplitInts();
            int result = RunIntcodeProgram(codes);
            return result;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        public static int RunIntcodeProgram(int[] codes)
        {
            int input = 1;
            int output = 0;
            int pc = 0; // Program counter
            while (true)
            {
                int ptr = codes[pc++];
                int opcode = GetOpCode(ptr);
                var mode1 = GetParameterMode(ptr, 1);
                var mode2 = GetParameterMode(ptr, 2);
                var mode3 = GetParameterMode(ptr, 3);
                switch (opcode)
                {
                    case 1: // Add
                        {
                            int ptrA = codes[pc++];
                            int ptrB = codes[pc++];
                            int ptrC = codes[pc++];
                            codes[ptrC] = GetValue(codes, ptrA, mode1) + GetValue(codes, ptrB, mode2);
                            break;
                        }
                    case 2: // Multiply
                        {
                            int ptrA = codes[pc++];
                            int ptrB = codes[pc++];
                            int ptrC = codes[pc++];
                            codes[ptrC] = GetValue(codes, ptrA, mode1) * GetValue(codes, ptrB, mode2);
                            break;
                        }
                    case 3: // Input
                        {
                            int ptrA = codes[pc++];
                            codes[ptrA] = input;
                            break;
                        }
                    case 4: // Output
                        {
                            int ptrA = codes[pc++];
                            output = GetValue(codes, ptrA, mode1);
                            Console.WriteLine(output);
                            break;
                        }
                    case 99: // Halt
                        return output;
                    default:
                        throw new Exception($"Unknown opcode {opcode} at position {pc}");
                }
            }
        }

        public static int GetValue(int[] codes, int ptr, ParameterMode mode) =>
            mode == ParameterMode.Immediate ? ptr : codes[ptr];

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
