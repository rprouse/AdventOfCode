using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2015
{
    public class Day08Tests : TestBase
    {
        const int DAY = 08;

        [TestCase( "\"\"", 0)]
        [TestCase( "\"abc\"", 3)]
        [TestCase( "\"aaa\\\"aaa\"", 7)]
        [TestCase( "\"\\x27\"", 1)]
        public void TestCountCharacters(string line, int expected)
        {
            Day08.CountCharacters(line).Should().Be(expected);
        }

        [Test]
        public void TestPartTwo()
        {
            Day08.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day08.PartOne(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day08.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 12);
            yield return new TestCaseData(PuzzleFile(DAY), 1096);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
