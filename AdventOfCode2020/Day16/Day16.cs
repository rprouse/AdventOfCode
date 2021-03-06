using System.Collections.Generic;
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
            int[] mine = GetTicket(lines[i++]);

            int sum = 0;
            i++;
            while(i < lines.Length)
            {
                int[] ticket = GetTicket(lines[i++]);
                foreach (int val in ticket)
                {
                    if (!rules.Any(r => r.Valid(val)))
                        sum += val;
                }
            }
            return sum;
        }

        public static long PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            int i = 0;
            List<Rule> rules = new List<Rule>();
            while (lines[i] != "your ticket:")
                rules.Add(new Rule(lines[i++]));

            i++;
            List<int> mine = GetTicket(lines[i++]).ToList();

            List<int[]> valid = new List<int[]>(new[] { mine.ToArray() });
            long result = 1;
            i++;
            while (i < lines.Length)
            {
                int[] ticket = GetTicket(lines[i++]);
                if (ticket.All(val => rules.Any(r => r.Valid(val))))
                    valid.Add(ticket);
            }

            // Pivot the tickets
            int len = valid[0].Length;
            List<int[]> rows = new List<int[]>(len);
            for(int x = 0; x < len; x++)
            {
                int[] row = new int[valid.Count];
                for (int y = 0; y < valid.Count; y++)
                    row[y] = valid[y][x];
                rows.Add(row);
            }
                        
            while (rules.Count > 0)
            {
                List<Rule> found = new List<Rule>();
                foreach (Rule rule in rules)
                {
                    var rowsFound = new List<int>();
                    for (int x = 0; x < rows.Count; x++)
                    {
                        if (rows[x].All(val => rule.Valid(val)))
                        {
                            rowsFound.Add(x);
                        }
                    }
                    if(rowsFound.Count == 1)
                    {
                        found.Add(rule);
                        if(rule.Name.StartsWith("departure"))
                            result *= mine[rowsFound[0]];

                        rows.RemoveAt(rowsFound[0]);
                        mine.RemoveAt(rowsFound[0]);
                    }
                }
                if (found.Count > 0)
                {
                    foreach (var rule in found)
                        rules.Remove(rule);
                }
            }
            return result;
        }

        internal static int[] GetTicket(string line) =>
            line.Split(',').Select(s => s.ToInt()).ToArray();
    }
}
