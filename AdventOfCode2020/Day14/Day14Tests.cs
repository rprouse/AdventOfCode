using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day14Tests : TestBase
    {
        const int DAY = 14;

        [Test]
        public void TestPartTwo()
        {
            Day14.PartTwo(PuzzleFile(DAY)).Should().Be(0L);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, long expected)
        {
            Day14.PartOne(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, long expected)
        {
            Day14.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 165L);
            yield return new TestCaseData(PuzzleFile(DAY), 14553106347726L);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0L);
            yield return new TestCaseData(PuzzleFile(DAY), 0L);
        }
    }
}
