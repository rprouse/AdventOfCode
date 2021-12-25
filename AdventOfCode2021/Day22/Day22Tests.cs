using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day22Tests : TestBase
{
    const int DAY = 22;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day22.PartOne(filename, true).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, long expected)
    {
        Day22.PartOne(filename, false).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 39);
        yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 590784);
        yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 474140);
        yield return new TestCaseData(PuzzleFile(DAY), 652209);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 2758514936282235);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
