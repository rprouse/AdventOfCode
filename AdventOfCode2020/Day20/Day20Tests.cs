using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day20Tests : TestBase
    {
        const int DAY = 20;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, long expected)
        {
            Day20.PartOne(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day20.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 20899048083289L);
            yield return new TestCaseData(PuzzleFile(DAY), 66020135789767L);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 273);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
