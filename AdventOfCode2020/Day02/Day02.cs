using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public class PasswordPolicy
    {
        public PasswordPolicy(string line)
        {
            string[] parts = line.Split(' ');
            string[] minMax = parts[0].Split('-');

            Min = minMax[0].ToInt();
            Max = minMax[1].ToInt();
            Char = parts[1][0];
            Password = parts[2];
        }

        public int Min { get; set; }
        public int Max { get; set; }
        public char Char { get; set; }
        public string Password { get; set; }

        public bool IsSledPolicyValid()
        {
            int count = Password.Where(c => c == Char).Count();
            return count >= Min && count <= Max;
        }

        public bool IsTobogganPolicyValid()
        {
            int count = Password.Where(c => c == Char).Count();
            return count >= Min && count <= Max;
        }
    }

    public static class Day02
    {
        public static int PartOne(string filename) =>
            filename.ReadAllLines()
                    .Select(l => new PasswordPolicy(l))
                    .Where(p => p.IsSledPolicyValid())
                    .Count();

        public static int PartTwo(string filename) =>
            filename.ReadAllLines()
                    .Select(l => new PasswordPolicy(l))
                    .Where(p => p.IsTobogganPolicyValid())
                    .Count();
    }
}
