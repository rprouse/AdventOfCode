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
            var chars = Enumerable.Range(0, 1000000000)
                .Select(i => CreateMD5($"{door}{i}"))
                .Where(h => h.StartsWith("00000"))
                .Select(h => h[5])
                .Take(8)
                .ToArray();
            return new string(chars);
        }

        public static string PartTwo(string door)
        {
            return "";
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
