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
    // Any with a zero
    public static int PartOne(string filename)
    {
        Ingredient[] ingredients = filename
            .ReadAllLines()
            .Select(l => new Ingredient(l))
            .ToArray();
        int max = 0;
        for(int i1 = 0; i1 <= 100; i1++)
        {
            int i2 = 100 - i1;
            int cap = ingredients[0].Capacity * i1 + ingredients[1].Capacity * i2;
            int dur = ingredients[0].Durability * i1 + ingredients[1].Durability * i2;
            int flv = ingredients[0].Flavor * i1 + ingredients[1].Flavor * i2;
            int tex = ingredients[0].Texture * i1 + ingredients[1].Texture * i2;
            if (cap <= 0 || dur <= 0 || flv <= 0 || tex <= 0)
                continue;

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
        return 0;
    }
}
