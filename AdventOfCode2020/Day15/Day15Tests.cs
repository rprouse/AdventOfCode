using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day15Tests : TestBase
    {
        const int DAY = 15;

        [Test]
        public void TestPartTwo()
        {
            Day15.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(int[] numbers, int expected)
        {
            Day15.PartOne(numbers).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day15.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(new[] { 0, 3, 6 }, 436);
            yield return new TestCaseData(new[] { 1, 3, 2 }, 1);
            yield return new TestCaseData(new[] { 2, 1, 3 }, 10);
            yield return new TestCaseData(new[] { 1, 2, 3 }, 27);
            yield return new TestCaseData(new[] { 2, 3, 1 }, 78);
            yield return new TestCaseData(new[] { 3, 2, 1 }, 438);
            yield return new TestCaseData(new[] { 3, 1, 2 }, 1836);
            yield return new TestCaseData(new[] { 1, 17, 0, 10, 18, 11, 6 }, 595);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
