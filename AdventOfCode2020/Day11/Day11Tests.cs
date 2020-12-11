using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day11Tests : TestBase
    {
        const int DAY = 11;

        [Test]
        public void TestPartTwo()
        {
            Day11.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day11.PartOne(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day11.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 37);
            yield return new TestCaseData(PuzzleFile(DAY), 2277);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
