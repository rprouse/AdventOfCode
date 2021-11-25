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

    [Test]
    public void TestPartOne()
    {
        Day15.PartOne(PuzzleFile(DAY)).Should().Be(0);
    }

    [Test]
    public void TestPartTwo()
    {
        Day15.PartTwo(PuzzleFile(DAY)).Should().Be(0);
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
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
