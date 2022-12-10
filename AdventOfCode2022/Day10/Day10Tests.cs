using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2022;

[Parallelizable(ParallelScope.All)]
public class Day10Tests : TestBase
{
    const int DAY = 10;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day10.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, string expected)
    {
        Day10.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 13140);
        yield return new TestCaseData(PuzzleFile(DAY), 14720);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY),
            "##..##..##..##..##..##..##..##..##..##..\r\n###...###..####..####...###...###..####.\r\n####...#####...#####....####....####....\r\n#####.....#####.....#####.....#####.....\r\n######......######......######......####\r\n#######.......#######.......#######.....\r\n");
        yield return new TestCaseData(PuzzleFile(DAY),
            "####.########..###.####..####.####.####.\r\n#.......#.#..#.#..#.#..#.#.......#.#....\r\n###....#.####..#..#.###.####....#.####..\r\n#.....#...#..#.###..#..#.#.....#...#....\r\n#....#....#..#.#....#..#.#....#....#....\r\n#....####.###..#...####..#....####.#....\r\n");
    }
}
