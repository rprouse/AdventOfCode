using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

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

    [TestCase(4, 8, 444356092776315)]
    [TestCase(6, 9, 0)]
    public void TestCasePartTwo(int p1, int p2, long expected)
    {
        Day21.PartTwo(p1, p2).Should().Be(expected);
    }
}
