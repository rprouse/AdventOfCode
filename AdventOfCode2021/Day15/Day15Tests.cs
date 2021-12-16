using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day15Tests : TestBase
{
    const int DAY = 15;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day15.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day15.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 40);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
