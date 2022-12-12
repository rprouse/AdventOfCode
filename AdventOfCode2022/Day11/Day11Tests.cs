using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022;

[Parallelizable(ParallelScope.All)]
public class Day11Tests : TestBase
{
    const int DAY = 11;

    [Test]
    public void CanCalculateLeastCommonMultipe()
    {
        Day11.LeastCommonMultiple(new uint[] { 23, 19, 13, 17 }).Should().Be(96577);
    }

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, ulong expected)
    {
        Day11.CalculateMonkeyBusiness(filename, 20, true).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, ulong expected)
    {
        Day11.CalculateMonkeyBusiness(filename, 10000, false).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 10605ul);
        yield return new TestCaseData(PuzzleFile(DAY), 61503ul);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 2713310158ul);
        yield return new TestCaseData(PuzzleFile(DAY), 0ul);
    }
}
