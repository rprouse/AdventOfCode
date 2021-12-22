using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day21Tests : TestBase
{
    const int DAY = 21;

    [TestCase(4, 8, 739785)]
    [TestCase(6, 9, 925605)]
    public void TestCasePartOne(int p1, int p2, int expected)
    {
        Day21.PartOne(p1, p2).Should().Be(expected);
    }

    [TestCase("", 0, Ignore = "If Needed")]
    public void TestCasePartTwo(string text, int expected)
    {
        Day21.PartTwo(text).Should().Be(expected);
    }
}
