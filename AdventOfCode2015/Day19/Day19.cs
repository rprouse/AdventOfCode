using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Core;
using NuGet.Frameworks;

namespace AdventOfCode2015;

public static class Day19
{
    public static int PartOne(string filename)
    {
        (var molecule, var substitutions) = ParseInput(filename);

        var molecules = new List<string>();
        for (int i = 0; i < molecule.Length; i++) 
        {
            if (!substitutions.ContainsKey(molecule[i])) continue;

            var firstPart = molecule.Substring(0, i);
            var lastPart = molecule.Substring(i + 1);
            foreach(var sub in substitutions[molecule[i]])
            {
                molecules.Add(firstPart + sub + lastPart);
            }
        }
        return molecules.Distinct().Count();
    }

    public static int PartTwo(string filename)
    {
        (var target, var substitutions) = ParseInput(filename);

        //// Add the e => substitutions
        //substitutions['e'] = substitutions.Keys.Select(c => c.ToString()).ToList();
        //int count = 0;
        //string molecule = "e";
        //var molecules = new List<string> { "e" };
        //while (true)
        //{
        //    count++;
        //    for (int i = 0; i < molecule.Length; i++)
        //    {
        //        if (!substitutions.ContainsKey(molecule[i])) continue;

        //        var firstPart = molecule.Substring(0, i);
        //        var lastPart = molecule.Substring(i + 1);
        //        foreach (var sub in substitutions[molecule[i]])
        //        {
        //            molecules.Add(firstPart + sub + lastPart);
        //        }
        //    }
        //}
        //return count;
        return 0;
    }

    static (string molecule, Dictionary<char, List<string>> substitutions) ParseInput(string filename)
    {
        string[] lines = filename
            .ReadAllLines()
            .Select(s => s.SimplifyInput())
            .ToArray();

        string molecule = lines[lines.Length - 1];
        var substitutions = new Dictionary<char, List<string>>();
        foreach (var line in lines)
        {
            if (line == molecule) break;
            char c = line[0];
            string sub = line.Substring(5);
            if (!substitutions.ContainsKey(c))
                substitutions.Add(c, new List<string>());

            substitutions[c].Add(sub);
        }
        return (molecule, substitutions);
    }

    // Reduce the molecules to one letter
    public static string SimplifyInput(this string str)
    {
        str = str.Replace("Al", "X");
        str = str.Replace("Th", "Z");
        return new string(str.Where(c => !char.IsLower(c)).ToArray());
    }
}
