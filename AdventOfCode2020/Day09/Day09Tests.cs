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

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int preamble, long expected)
        {
            Day09.PartOne(filename, preamble).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, long mismatch, long expected)
        {
            Day09.PartTwo(filename, mismatch).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 5, 127);
            yield return new TestCaseData(PuzzleFile(DAY), 25, 1398413738L);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 127, 62);
            yield return new TestCaseData(PuzzleFile(DAY), 1398413738L, 169521051L);
        }
    }
}
