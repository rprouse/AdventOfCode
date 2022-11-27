using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2015;

public class Day17Tests : TestBase
{
    const int DAY = 17;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int target, int expected)
    {
        Day17.PartOne(filename, target).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int target, int expected)
    {
        Day17.PartTwo(filename, target).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 25, 4);
        yield return new TestCaseData(PuzzleFile(DAY), 150, 654);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 25, 0);
        yield return new TestCaseData(PuzzleFile(DAY), 150, 0);
    }
}
