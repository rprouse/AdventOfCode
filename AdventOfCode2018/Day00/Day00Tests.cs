using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2018
{
    public class Day00Tests : TestBase
    {
        const int DAY = 00;

        [Test]
        public void TestPartOne()
        {
            Day00.PartOne(PuzzleFile(DAY)).ShouldBe(0);
        }

        [Test]
        public void TestPartTwo()
        {
            Day00.PartTwo(PuzzleFile(DAY)).ShouldBe(0);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day00.PartOne(filename).ShouldBe(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day00.PartTwo(filename).ShouldBe(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
