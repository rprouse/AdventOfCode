using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day14Tests : TestBase
{
    const int DAY = 14;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, long expected)
    {
        Day14.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, long expected)
    {
        Day14.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 1588);
        yield return new TestCaseData(PuzzleFile(DAY), 2621);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 2188189693529);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
