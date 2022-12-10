using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022;

[Parallelizable(ParallelScope.All)]
public class Day09Tests : TestBase
{
    const int DAY = 09;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day09.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day09.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 13);
        yield return new TestCaseData(PuzzleFile(DAY), 5960);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 1);
        yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 36);
        yield return new TestCaseData(PuzzleFile(DAY), 2327);
    }
}
