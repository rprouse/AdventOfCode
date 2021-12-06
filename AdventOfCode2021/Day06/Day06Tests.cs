using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;
using System.Linq;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day06Tests : TestBase
{
    const int DAY = 06;

    [Test]
    public void TestPartOne()
    {
        Day06.PartOne(PuzzleFile(DAY)).Should().Be(396210);
    }

    [Test]
    public void TestPartTwo()
    {
        Day06.PartTwo(PuzzleFile(DAY)).Should().Be(1770823541496);
    }

    [TestCase(18, 26)]
    [TestCase(80, 5934)]
    [TestCase(16, 21)]
    [TestCase(32, 88)]
    [TestCase(48, 361)]
    [TestCase(64, 1467)]
    [TestCase(80, 5934)]
    [TestCase(96, 23948)]
    [TestCase(112, 96540)]
    [TestCase(128, 388976)]
    [TestCase(144, 1566923)]
    [TestCase(160, 6311710)]
    [TestCase(176, 25424473)]
    [TestCase(192, 102417953)]
    [TestCase(256, 26984457539)]
    public void TestCasePartOne(int days, long expected)
    {
        var fish = "3,4,3,1,2".Split(',').Select(c => c.ToInt()).ToList();
        Day06.ReproduceFishForDays(fish.ToList(), days).Should().Be(expected);
    }
}
