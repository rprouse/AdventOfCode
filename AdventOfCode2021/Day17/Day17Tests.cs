using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day17Tests : TestBase
{
    const int DAY = 17;

    [TestCase(20, 30, -10, -5, 45)]
    [TestCase(269, 292, -68, -44, 2278)]
    public void TestCasePartOne(int x1, int x2, int y1, int y2, int expected)
    {
        var targetArea = new Day17.TargetArea(x1, x2, y1, y2);
        Day17.PartOne(targetArea).Should().Be(expected);
    }

    [TestCase(20, 30, -10, -5, 45)]
    [TestCase(269, 292, -68, -44, 0)]
    public void TestCasePartTwo(int x1, int x2, int y1, int y2, int expected)
    {
        var targetArea = new Day17.TargetArea(x1, x2, y1, y2);
        Day17.PartTwo(targetArea).Should().Be(expected);
    }
}
