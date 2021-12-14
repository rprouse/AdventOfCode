using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day13Tests : TestBase
{
    const int DAY = 13;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day13.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day13.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 17);
        yield return new TestCaseData(PuzzleFile(DAY), 753);
    }

    // #..#.####.#....####.#..#...##.###..#..#
    // #..#....#.#....#....#..#....#.#..#.#.#.
    // ####...#..#....###..####....#.#..#.##..
    // #..#..#...#....#....#..#....#.###..#.#.
    // #..#.#....#....#....#..#.#..#.#.#..#.#.
    // #..#.####.####.####.#..#..##..#..#.#..#
    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
