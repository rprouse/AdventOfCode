using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day10Tests : TestBase
{
    const int DAY = 10;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, long expected)
    {
        Day10.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, long expected)
    {
        Day10.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 26397);
        yield return new TestCaseData(PuzzleFile(DAY), 311949);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 288957);
        yield return new TestCaseData(PuzzleFile(DAY), 3042730309);
    }
}
