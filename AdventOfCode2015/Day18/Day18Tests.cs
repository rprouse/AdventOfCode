using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2015;

public class Day18Tests : TestBase
{
    const int DAY = 18;

    [TestCase(0, 0, 1)]
    [TestCase(1, 0, 0)]
    [TestCase(3, 0, 2)]
    [TestCase(5, 0, 1)]
    [TestCase(0, 1, 2)]
    [TestCase(2, 2, 2)]
    [TestCase(5, 1, 3)]
    [TestCase(0, 5, 2)]
    [TestCase(5, 5, 1)]
    public void CanCountNeighbors(int x, int y, int expected)
    {
        var life = new ConwaysGameOfLife(TestFile(DAY));
        life.Neighbors(x, y).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int steps, int expected)
    {
        Day18.PartOne(filename, steps).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int steps, int expected)
    {
        Day18.PartTwo(filename, steps).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 4, 4);
        yield return new TestCaseData(PuzzleFile(DAY), 100, 814);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
