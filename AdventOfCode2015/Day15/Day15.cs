using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using FluentAssertions.Execution;
using NuGet.Frameworks;

namespace AdventOfCode2015;

public class Ingredient
{
    public Ingredient(string line)
    {
        var p1 = line.Split(": ");
        Name = p1[0];
        var p2 = p1[1].Split(", ");
        Capacity = SplitOutInt(p2[0]);
        Durability = SplitOutInt(p2[1]);
        Flavor = SplitOutInt(p2[2]);
        Texture = SplitOutInt(p2[3]);
        Calories = SplitOutInt(p2[4]);
    }

    // string like "capacity -1"
    int SplitOutInt(string part) => part.Split(' ')[1].ToInt();

    public string Name { get; }
    public int Capacity { get; }
    public int Durability { get; }
    public int Flavor { get; }
    public int Texture { get; }
    public int Calories { get; }
}

public static class Day15
{
    const int TOTAL = 100;

    static IEnumerable<int[]> Combinations2()
    {
        for (int a = 1; a <= TOTAL - 1; a++)
            for (int b = 1; b <= TOTAL - 1; b++)
                if (a + b == TOTAL) yield return new[] { a, b };
    }

    static IEnumerable<int[]> Combinations4()
    {
        for (int a = 3; a <= TOTAL - 3; a++)
            for (int b = 3; b <= TOTAL - 3; b++)
                for (int c = 3; c <= TOTAL - 3; c++)
                    for (int d = 3; d <= TOTAL - 3; d++)
                        if (a + b + c + d == TOTAL) yield return new[] { a, b, c, d };
    }

    // Any with a zero
    public static int PartOne(string filename)
    {
        Ingredient[] ingredients = filename
            .ReadAllLines()
            .Select(l => new Ingredient(l))
            .ToArray();
        int max = 0;
        var range = Enumerable.Range(0, ingredients.Length).ToArray();
        var combinations = ingredients.Length == 2 ? Combinations2() : Combinations4();
        foreach (var i in combinations)
        {
            int cap = range.Sum(n => ingredients[n].Capacity * i[n]);
            if (cap <= 0) continue;
            int dur = range.Sum(n => ingredients[n].Durability * i[n]);
            if (dur <= 0) continue;
            int flv = range.Sum(n => ingredients[n].Flavor * i[n]);
            if (flv <= 0) continue;
            int tex = range.Sum(n => ingredients[n].Texture * i[n]);
            if (tex <= 0) continue;

            int score = cap * dur * flv * tex;
            if (score > max) max = score;
        }
        return max;
    }

    public static int PartTwo(string filename)
    {
        Ingredient[] ingredients = filename
            .ReadAllLines()
            .Select(l => new Ingredient(l))
            .ToArray();
        int max = 0;
        var range = Enumerable.Range(0, ingredients.Length).ToArray();
        var combinations = ingredients.Length == 2 ? Combinations2() : Combinations4();
        foreach (var i in combinations)
        {
            int cap = range.Sum(n => ingredients[n].Capacity * i[n]);
            if (cap <= 0) continue;
            int dur = range.Sum(n => ingredients[n].Durability * i[n]);
            if (dur <= 0) continue;
            int flv = range.Sum(n => ingredients[n].Flavor * i[n]);
            if (flv <= 0) continue;
            int tex = range.Sum(n => ingredients[n].Texture * i[n]);
            if (tex <= 0) continue;
            int cal = range.Sum(n => ingredients[n].Calories * i[n]);
            if (cal != 500) continue;

            int score = cap * dur * flv * tex;
            if (score > max) max = score;
        }
        return max;
    }
}
