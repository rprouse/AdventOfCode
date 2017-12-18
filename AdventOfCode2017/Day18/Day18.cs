using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day18
    {
        public static long PartOne(string[] program)
        {
            int ptr = 0;
            long frq = 0;
            var registers = new Dictionary<char, long>();
            while(true)
            {
                if (ptr < 0 || ptr >= program.Length || string.IsNullOrEmpty(program[ptr]))
                    break;

                string instr = program[ptr];
                char reg = instr[4];
                long val = 0;
                if (instr.Length > 6)
                {
                    string valStr = instr.Substring(6);
                    if (!long.TryParse(valStr, out val))
                    {
                        if (registers.ContainsKey(valStr[0]))
                            val = registers[valStr[0]];
                    }
                }
                if (!registers.ContainsKey(reg))
                    registers.Add(reg, 0);

                switch (instr.Substring(0, 3))
                {
                    case "snd":
                        frq = registers[reg];
                        ptr++;
                        break;
                    case "set":
                        registers[reg] = val;
                        ptr++;
                        break;
                    case "add":
                        registers[reg] = registers[reg] + val;
                        ptr++;
                        break;
                    case "mul":
                        registers[reg] = registers[reg] * val;
                        ptr++;
                        break;
                    case "mod":
                        registers[reg] = registers[reg] % val;
                        ptr++;
                        break;
                    case "rcv":
                        ptr = -1;   // Jump out of the program
                        break;
                    case "jgz":
                        if (registers[reg] > 0)
                            ptr += (int)val;
                        else
                            ptr++;
                        break;
                }
            }
            return frq;
        }

        public static long PartTwo(string[] program)
        {
            return 0;
        }
    }
}
