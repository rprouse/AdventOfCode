using System.Collections;
using System.Drawing;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day09Tests : TestBase
{
    const int DAY = 09;

    [TestCase(1, 0, 3)]
    [TestCase(9, 0, 9)]
    [TestCase(2, 2, 14)]
    [TestCase(6, 4, 9)]
    public void TestBasinSize(int x, int y, int expected)
    {
        var map = Day09.GetMap(TestFile(DAY));
        map = Day09.AddBorderToMap(map);
        Day09.BasinSize(map, new Point(x+1, y+1)).Should().Be(expected);
    }

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
        yield return new TestCaseData(TestFile(DAY), 15);
        yield return new TestCaseData(PuzzleFile(DAY), 465);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 1134);
        yield return new TestCaseData(PuzzleFile(DAY), 1269555);
    }
}
