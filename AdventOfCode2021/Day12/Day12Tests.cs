using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day12Tests : TestBase
{
    const int DAY = 12;

    [TestCase("", 0, Ignore = "If Needed")]
    public void TestCasePartOne(string text, int expected)
    {
        Day12.PartOne(text).Should().Be(expected);
    }

    [TestCase("", 0, Ignore = "If Needed")]
    public void TestCasePartTwo(string text, int expected)
    {
        Day12.PartTwo(text).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day12.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day12.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 10);
        yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 19);
        yield return new TestCaseData(TestFile(DAY, "Test3.txt"), 226);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
