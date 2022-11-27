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
        string[] lines = filename
            .ReadAllLines()
            .Select(s => s.SimplifyInput())
            .ToArray();

        string start = lines[lines.Length - 1];
        var substitutions = new Dictionary<char, List<string>>();
        foreach (var line in lines) 
        {
            if (line == start) break;
            char c = line[0];
            string sub = line.Substring(5);
            if (!substitutions.ContainsKey(c))
                substitutions.Add(c, new List<string>());

            substitutions[c].Add(sub);
        }

        var molecules = new List<string>();
        for (int i = 0; i < start.Length; i++) 
        {
            if (!substitutions.ContainsKey(start[i])) continue;

            var firstPart = start.Substring(0, i);
            var lastPart = start.Substring(i + 1);
            foreach(var sub in substitutions[start[i]])
            {
                molecules.Add(firstPart + sub + lastPart);
            }
        }
        return molecules.Distinct().Count();
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }

    // Reduce the molecules to one letter
    public static string SimplifyInput(this string str)
    {
        str = str.Replace("Al", "X");
        str = str.Replace("Th", "Z");
        return new string(str.Where(c => !char.IsLower(c)).ToArray());
    }
}
