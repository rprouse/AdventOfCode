using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public static class Day05
    {
        public static string PartOne(string door)
        {
            using (var md5 = MD5.Create())
            {
                var chars = Enumerable.Range(0, 1000000000)
                    .Select(i => {
                        byte[] inputBytes = Encoding.ASCII.GetBytes($"{door}{i}");
                        byte[] hashBytes = md5.ComputeHash(inputBytes);
                        if (hashBytes[0] == 0 && hashBytes[1] == 0 && hashBytes[2] < 0x10)
                            return hashBytes[2].ToString("x2")[1];
                        else
                            return (char)0x0;
                    })
                    .Where(c => c != 0x0)
                    .Take(8)
                    .ToArray();
                return new string(chars);
            }
        }

        public static string PartTwo(string door)
        {
            char[] r = new char[8];
            using (var md5 = MD5.Create())
            {
                Longs()
                    .Select(i => {
                        byte[] inputBytes = Encoding.ASCII.GetBytes($"{door}{i}");
                        byte[] hashBytes = md5.ComputeHash(inputBytes);
                        if (hashBytes[0] == 0 && hashBytes[1] == 0 && hashBytes[2] <= 0x07 && r[hashBytes[2]] == 0x0)
                        {
                            // Icky side effects, shield your eyes ;P
                            r[hashBytes[2]] = hashBytes[3].ToString("x2")[0];
                            return true;
                        }
                        else
                            return false;
                    })
                    .Where(b => b)
                    .Take(8)
                    .ToArray();
            }
            return new string(r);
        }

        static IEnumerable<long> Longs()
        {
            for (long l = 0; l <= long.MaxValue; l++) yield return l;
        }

        static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
