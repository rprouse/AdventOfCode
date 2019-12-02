using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day02
    {
        public static int PartOne(string filename)
        {
            int[] codes = filename.SplitInts();
            codes[1] = 12;
            codes[2] = 2;
            int[] result = RunIntcodeProgram(codes);
            return result[0];
        }

        public static int PartTwo(string filename)
        {
            int[] codes = filename.SplitInts();
            return 0;
        }

        public static int[] RunIntcodeProgram(int[] codes)
        {
            int pc = 0; // Program counter
            while(true)
            {
                int opcode = codes[pc++];
                switch(opcode)
                {
                    case 1: // Add
                    {
                        int ptrA = codes[pc++];
                        int ptrB = codes[pc++];
                        int ptrC = codes[pc++];
                        codes[ptrC] = codes[ptrA] + codes[ptrB];
                        break;
                    }
                    case 2: // Multiply
                    {
                        int ptrA = codes[pc++];
                        int ptrB = codes[pc++];
                        int ptrC = codes[pc++];
                        codes[ptrC] = codes[ptrA] * codes[ptrB];
                        break;
                    }
                    case 99: // Exit
                        return codes;
                    default:
                        throw new Exception($"Unknown opcode {opcode} at position {pc}");
                }
            }
        }
    }
}
