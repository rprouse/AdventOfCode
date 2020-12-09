using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day09Tests : TestBase
    {
        const int DAY = 09;

        [Test]
        public void TestPartOne()
        {
            Day09.PartOne(PuzzleFile(DAY), 25).Should().Be(0);
        }

        [Test]
        public void TestPartTwo()
        {
            Day09.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int preamble, int expected)
        {
            Day09.PartOne(filename, preamble).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day09.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 5, 127);
            yield return new TestCaseData(PuzzleFile(DAY), 25, 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
