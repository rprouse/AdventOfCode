using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    public class Day01Tests : TestBase
    {
        const int DAY = 01;

        [Test]
        public void TestPartTwo()
        {
            Day01.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day01.PartOne(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 514579);
            yield return new TestCaseData(PuzzleFile(DAY), 703131);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 241861950);
            yield return new TestCaseData(PuzzleFile(DAY), 272423970);
        }
    }
}
