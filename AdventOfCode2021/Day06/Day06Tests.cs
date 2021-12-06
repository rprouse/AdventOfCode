using System.Linq;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day06Tests : TestBase
{
    const int DAY = 06;

    [TestCase(80, 396210)]
    [TestCase(256, 1770823541496)]
    public void TestDay06Answers(int days, long expected)
    {
        Day06.ReproduceFishForDays(PuzzleFile(DAY).SplitInts(), days)
            .Should()
            .Be(expected);
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
    public void TestReproduceFishForDays(int days, long expected)
    {
        var fish = "3,4,3,1,2".Split(',').Select(c => c.ToInt());
        Day06.ReproduceFishForDays(fish.ToList(), days).Should().Be(expected);
    }
}
