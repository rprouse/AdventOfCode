using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2022;

[Parallelizable(ParallelScope.All)]
public class Day07Tests : TestBase
{
    const int DAY = 07;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, long expected)
    {
        Day07.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, long expected)
    {
        Day07.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 95437L);
        yield return new TestCaseData(PuzzleFile(DAY), 1243729L);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 24933642);
        yield return new TestCaseData(PuzzleFile(DAY), 4443914);
    }
}
