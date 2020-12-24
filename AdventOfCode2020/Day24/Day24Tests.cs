using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day24Tests : TestBase
    {
        const int DAY = 24;

        [TestCase("esew", 0, 1)]
        [TestCase("esenee", 3, 0)]
        public void TestMakeMoves(string moves, int x, int y)
        {
            Day24.MakeMoves(moves).Should().Be((x, y));
        }

        [Test]
        public void TestPartTwo()
        {
            Day24.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day24.PartOne(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day24.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 10);
            yield return new TestCaseData(PuzzleFile(DAY), 420);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
