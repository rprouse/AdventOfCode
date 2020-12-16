using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day16
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            int i = 0;
            List<Rule> rules = new List<Rule>();
            while (lines[i] != "your ticket:")
                rules.Add(new Rule(lines[i++]));

            i++;
            int[] mine = lines[i++].Split(',').Select(s => s.ToInt()).ToArray();

            int sum = 0;
            i++;
            while(i < lines.Length)
            {
                int[] ticket = lines[i++].Split(',').Select(s => s.ToInt()).ToArray();
                foreach(int val in ticket)
                {
                    if (!rules.Any(r => r.Valid(val)))
                        sum += val;
                }
            }
            return sum;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }

    public class Rule
    {
        public string Name { get; set; }
        public int LowOne { get; set; }
        public int HighOne { get; set; }
        public int LowTwo { get; set; }
        public int HighTwo { get; set; }

        public Rule(string line)
        {
            string[] parts = line.Split(": ");
            Name = parts[0];

            string[] ranges = parts[1].Split(" or ");
            string[] range = ranges[0].Split("-");
            LowOne = range[0].ToInt();
            HighOne = range[1].ToInt();

            range = ranges[1].Split("-");
            LowTwo = range[0].ToInt();
            HighTwo = range[1].ToInt();
        }

        public bool Valid(int n) =>
            (n >= LowOne && n <= HighOne) || (n >= LowTwo && n <= HighTwo); 
    }
}
