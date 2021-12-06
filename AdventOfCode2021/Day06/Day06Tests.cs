using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;
using System.Linq;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day06Tests : TestBase
{
    const int DAY = 06;

    [Test]
    public void TestPartOne()
    {
        Day06.PartOne(PuzzleFile(DAY)).Should().Be(396210);
    }

    [Test]
    public void TestPartTwo()
    {
        Day06.PartTwo(PuzzleFile(DAY)).Should().Be(0);
    }

    [TestCase("3,4,3,1,2", 18, 26)]
    [TestCase("3,4,3,1,2", 80, 5934)]
    public void TestCasePartOne(string text, int days, int expected)
    {
        var fish = text.Split(',').Select(c => c.ToInt()).ToList();
        Day06.ReproduceFishForDays(fish.ToList(), days).Should().Be(expected);
    }

    [TestCase("", 0, Ignore = "If Needed")]
    public void TestCasePartTwo(string text, int expected)
    {
        Day06.PartTwo(text).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day06.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
