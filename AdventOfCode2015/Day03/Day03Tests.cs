using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2015
{
    public class Day03Tests : TestBase
    {
        const int DAY = 03;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string line, int expected)
        {
            Day03.PartOne(line).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string line, int expected)
        {
            Day03.PartTwo(line).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(">", 2);
            yield return new TestCaseData("^>v<", 4);
            yield return new TestCaseData("^v^v^v^v^v", 2);
            yield return new TestCaseData(PuzzleFile(DAY).ReadAll().Trim(), 2081);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData("^v", 3);
            yield return new TestCaseData("^>v<", 3);
            yield return new TestCaseData("^v^v^v^v^v", 11);
            yield return new TestCaseData(PuzzleFile(DAY).ReadAll().Trim(), 0);
        }
    }
}
