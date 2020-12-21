using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day21Tests : TestBase
    {
        const int DAY = 21;

        [Test]
        public void TestPartOne()
        {
            Day21.PartOne(PuzzleFile(DAY)).Should().Be(0);
        }

        [Test]
        public void TestPartTwo()
        {
            Day21.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day21.PartOne(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day21.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 5);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
