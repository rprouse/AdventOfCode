using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2015;

public class Day17Tests : TestBase
{
    const int DAY = 17;

    [Test]
    public void TestPartTwo()
    {
        Day17.PartTwo(PuzzleFile(DAY)).Should().Be(0);
    }

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int target, int expected)
    {
        Day17.PartOne(filename, target).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day17.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 25, 4);
        yield return new TestCaseData(PuzzleFile(DAY), 150, 0);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
