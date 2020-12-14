using System;
using System.Collections.Generic;
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
            Dictionary<long, long> memory = new Dictionary<long, long>();
            string mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            foreach (string line in lines)
            {
                string[] parts = line.Split(" = ");
                if (parts[0] == "mask")
                {
                    mask = parts[1];
                }
                else
                {
                    long ptr = parts[0][4..^1].ToLong();
                    long val = parts[1].ToLong();
                    WriteMemoryv2(memory, mask, ptr, val);
                }
            }
            return memory.Values.Sum(u => u);
        }

        internal static void WriteMemoryv2(Dictionary<long, long> memory, string mask, long ptr, long val)
        {
            var addressMask = GetAddressMask(mask, ptr);
            var addresses = AddressesFromMask(addressMask);
            foreach (var addr in addresses)
                memory[addr] = val;
        }

        internal static IList<long> AddressesFromMask(string mask)
        {
            int pos = mask.IndexOf('X');
            var addresses = ReplaceXInMask(mask.ToCharArray(), pos);
            return addresses.Select(a => FromMask(a)).ToList();
        }

        internal static long FromMask(char[] mask) =>
            Convert.ToInt64(new string(mask), 2);

        internal static IEnumerable<char[]> ReplaceXInMask(char[] mask, int pos)
        {
            char[] zero = (char[])mask.Clone();
            zero[pos] = '0';
            char[] one = (char[])mask.Clone();
            one[pos] = '1';

            int nextXPos = Array.IndexOf(zero, 'X');
            if(nextXPos == -1)
            {
                return new[] { zero, one };
            }

            var masks = new List<char[]>(ReplaceXInMask(zero, nextXPos));
            masks.AddRange(ReplaceXInMask(one, nextXPos));
            return masks;
        }

        internal static string GetAddressMask(string mask, long ptr)
        {
            char[] addressMask = new char[36];
            for (int i = 0; i < 36; i++)
            {
                long binary = ptr >> (35 - i) & 1L;
                addressMask[i] = binary == 0 ? '0' : '1';

                switch (mask[i])
                {
                    case 'X': // floating
                        addressMask[i] = 'X';
                        break;
                    case '1': // overwrite
                        addressMask[i] = '1';
                        break;
                    case '0': // unchanged
                        break;
                    default:
                        throw new Exception($"Unexpected char {mask[i]} in mask");
                }
            }
            return new string(addressMask);
        }
    }
}
