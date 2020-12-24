using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day23Tests : TestBase
    {
        const int DAY = 23;

        [TestCase("389125467", 10, "92658374")]
        [TestCase("389125467", 100, "67384529")]
        [TestCase("247819356", 100, "76385429")]
        public void TestPartOne(string cups, int moves, string expected)
        {
            Day23.PartOne(cups, moves).Should().Be(expected);
        }

        [TestCase(-1, 8)]
        [TestCase(0, 0)]
        [TestCase(8, 8)]
        [TestCase(9, 0)]
        [TestCase(10, 1)]
        [TestCase(11, 2)]
        [TestCase(12, 3)]
        public void TestWrap(int cup, int expected)
        {
            Day23.Wrap(cup).Should().Be(expected);
        }

        [TestCase("389125467", 10000000, "67384529")]
        [TestCase("247819356", 10000000, "76385429")]
        public void TestPartTwo(string cups, int moves, string expected)
        {
            Day23.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }
    }
}
