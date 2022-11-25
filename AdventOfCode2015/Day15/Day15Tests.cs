using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2015;

public class Day15Tests : TestBase
{
    const int DAY = 15;

    [TestCase("Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8", "Butterscotch", -1, -2, 6, 3, 8)]
    [TestCase("Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3", "Cinnamon", 2, 3, -2, -1, 3)]
    public void CanParseIngredient(string line, string name, int cap, int dur, int flv, int txt, int cal)
    {
        var ingredient = new Ingredient(line);
        ingredient.Name.Should().Be(name);
        ingredient.Capacity.Should().Be(cap);
        ingredient.Durability.Should().Be(dur);
        ingredient.Flavor.Should().Be(flv);
        ingredient.Texture.Should().Be(txt);
        ingredient.Calories.Should().Be(cal);
    }

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day15.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day15.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 62842880);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
