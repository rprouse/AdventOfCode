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

    [TestCase("target area: x=269..292, y=-68..-44", 0)]
    [TestCase("target area: x=269..292, y=-68..-44", 0)]
    public void TestCasePartOne(string targetArea, int expected)
    {
        Day17.PartOne(targetArea).Should().Be(expected);
    }

    [TestCase("target area: x=269..292, y=-68..-44", 0)]
    [TestCase("target area: x=269..292, y=-68..-44", 0)]
    public void TestCasePartTwo(string targetArea, int expected)
    {
        Day17.PartTwo(targetArea).Should().Be(expected);
    }
}
