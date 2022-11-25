using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015;

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
    public static int PartOne(string filename) =>
        CalculateMaxScore(filename, false);

    public static int PartTwo(string filename) =>
        CalculateMaxScore(filename, true);

    private static int CalculateMaxScore(string filename, bool countCalories)
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
            if (countCalories && cal != 500) continue;

            int score = cap * dur * flv * tex;
            if (score > max) max = score;
        }
        return max;
    }
}
