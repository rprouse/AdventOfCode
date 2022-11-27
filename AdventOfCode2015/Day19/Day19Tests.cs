using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2015;

public class Day19Tests : TestBase
{
    const int DAY = 19;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day19.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day19.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 4);
        yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 7);
        yield return new TestCaseData(PuzzleFile(DAY), 576);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 3);
        yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 6);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
