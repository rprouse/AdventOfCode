using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day21
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            Dictionary<string, List<string>> allergens = new Dictionary<string, List<string>>();
            List<string> allFoods = new List<string>();
            foreach (string line in lines)
            {
                var parts = line.Split(" (contains ");
                var foods = parts[0].Split(" ");
                allFoods.AddRange(foods);
                var contains = parts[1][..^1].Split(", ");
                foreach (string str in contains)
                {
                    if (allergens.ContainsKey(str))
                    {
                        allergens[str] = allergens[str].Where(f => foods.Contains(f)).ToList();
                    }
                    else
                    {
                        allergens[str] = new List<string>(foods);
                    }
                }
            }

            while (!allergens.Values.All(v => v.Count == 1))
            {
                var singles = allergens.Values.Where(v => v.Count == 1).Select(v => v[0]);
                foreach(var pair in allergens.Where(p => p.Value.Count > 1))
                {
                    var newlist = pair.Value.Where(v => !singles.Contains(v)).ToList();
                    pair.Value.Clear();
                    pair.Value.AddRange(newlist);
                }
            }

            //allFoods = allFoods.ToList();
            foreach (var pair in allergens)
            {
                if (pair.Value.Count != 1)
                    Console.WriteLine($"{pair.Key} still has {pair.Value.Count} foods");
                else
                {
                    int pos = allFoods.IndexOf(pair.Value[0]);
                    while (pos != -1)
                    {
                        allFoods.RemoveAt(pos);
                        pos = allFoods.IndexOf(pair.Value[0]);
                    }
                }
            }

            return allFoods.Count;
        }

        public static string PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            Dictionary<string, List<string>> allergens = new Dictionary<string, List<string>>();
            foreach (string line in lines)
            {
                var parts = line.Split(" (contains ");
                var foods = parts[0].Split(" ");
                var contains = parts[1][..^1].Split(", ");
                foreach (string str in contains)
                {
                    if (allergens.ContainsKey(str))
                    {
                        allergens[str] = allergens[str].Where(f => foods.Contains(f)).ToList();
                    }
                    else
                    {
                        allergens[str] = new List<string>(foods);
                    }
                }
            }

            while (!allergens.Values.All(v => v.Count == 1))
            {
                var singles = allergens.Values.Where(v => v.Count == 1).Select(v => v[0]);
                foreach (var pair in allergens.Where(p => p.Value.Count > 1))
                {
                    var newlist = pair.Value.Where(v => !singles.Contains(v)).ToList();
                    pair.Value.Clear();
                    pair.Value.AddRange(newlist);
                }
            }

            return string.Join(",", allergens.OrderBy(a => a.Key).Select(a => a.Value[0]));
        }
    }
}
