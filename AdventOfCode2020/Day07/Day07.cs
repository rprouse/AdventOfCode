using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day07
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            var rules = ParseRules(lines);
            bool found = true;
            List<string> holds = new List<string>();
            List<string> lookingFor = rules.Where(r => r.Value.Keys.Contains("shiny gold")).Select(r => r.Key).ToList();
            holds.AddRange(lookingFor);
            while(found)
            {
                found = false;
                List<string> newLooking = new List<string>();
                foreach (string color in lookingFor)
                {
                    newLooking.AddRange(rules.Where(r => r.Value.Keys.Contains(color)).Select(r => r.Key));
                }
                if (newLooking.Any())
                {
                    lookingFor = newLooking.Distinct().ToList();
                    holds.AddRange(newLooking);
                    found = true;
                }
            }
            return holds.Distinct().Count();
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            var rules = ParseRules(lines);
            return BagsForColor(rules, "shiny gold");
        }

        static int BagsForColor(Dictionary<string, Dictionary<string, int>> rules, string color)
        {
            if (!rules.ContainsKey(color) || !rules[color].Any())
                return 0;

            int count = 0;
            foreach(var child in rules[color])
            {
                count += child.Value;
                count += BagsForColor(rules, child.Key) * child.Value;
            }
            return count;
        }

        static Dictionary<string, Dictionary<string, int>> ParseRules(string[] lines)
        {
            var ret = new Dictionary<string, Dictionary<string, int>>(lines.Length);
            foreach(var line in lines)
            {
                var rule = new Dictionary<string, int>();
                string[] parts = line.Split(' ');
                string bag = $"{parts[0]} {parts[1]}";

                int c = line.IndexOf("contain ");
                string children = line.Substring(c + 8);
                if (!children.StartsWith("no other"))
                {
                    string[] childBags = children.Split(", ");
                    foreach(var childBag in childBags)
                    {
                        string[] subparts = childBag.Split(' ');
                        int n = subparts[0].ToInt();
                        string color = $"{subparts[1]} {subparts[2]}";
                        rule.Add(color, n);
                    }
                }
                ret.Add(bag, rule);
            }
            return ret;
        }
    }
}
