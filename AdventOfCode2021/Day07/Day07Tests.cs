using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day07Tests : TestBase
{
    const int DAY = 07;

    [TestCase(-9, 45)]
    [TestCase(-3, 6)]
    [TestCase(1, 1)]
    [TestCase(2, 3)]
    [TestCase(3, 6)]
    [TestCase(4, 10)]
    [TestCase(5, 15)]
    [TestCase(9, 45)]
    [TestCase(11, 66)]
    public void TestCalculateFuel(int steps, int expected)
    {
        Day07.CalculateFuel(steps).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day07.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day07.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 37);
        yield return new TestCaseData(PuzzleFile(DAY), 344138);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 168);
        yield return new TestCaseData(PuzzleFile(DAY), 94862124);
    }
}
