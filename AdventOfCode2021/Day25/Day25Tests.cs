using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day25Tests : TestBase
{
    const int DAY = 25;

    [Test]
    public void TestPartOne()
    {
        Day25.PartOne(PuzzleFile(DAY)).Should().Be(0);
    }

    [Test]
    public void TestPartTwo()
    {
        Day25.PartTwo(PuzzleFile(DAY)).Should().Be(0);
    }

    [TestCase("", 0, Ignore = "If Needed")]
    public void TestCasePartOne(string text, int expected)
    {
        Day25.PartOne(text).Should().Be(expected);
    }

    [TestCase("", 0, Ignore = "If Needed")]
    public void TestCasePartTwo(string text, int expected)
    {
        Day25.PartTwo(text).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day25.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day25.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
