using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day14
    {
        public static long PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            Dictionary<uint, long> memory = new Dictionary<uint, long>();
            string mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            foreach(string line in lines)
            {
                string[] parts = line.Split(" = ");
                if(parts[0] == "mask")
                {
                    mask = parts[1];
                }
                else
                {
                    uint ptr = parts[0][4..^1].ToUint();
                    long val = parts[1].ToLong();
                    WriteMemory(memory, mask, ptr, val);
                }
            }
            return memory.Values.Sum(u => u);
        }

        internal static void WriteMemory(Dictionary<uint, long> memory, string mask, uint ptr, long val)
        {
            for(int i = 0; i < 36; i++)
            {
                switch(mask[i])
                {
                    case 'X':
                        break;
                    case '1':
                        long onemask = 1L << (35 - i);
                        val = val | onemask;
                        break;
                    case '0':
                        long zeromask = (1L << (35 - i)) ^ long.MaxValue;
                        val = val & zeromask;
                        break;
                    default:
                        throw new Exception($"Unexpected char {mask[i]} in mask");
                }
            }
            memory[ptr] = val;
        }

        public static long PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0L;
        }
    }
}
