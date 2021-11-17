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
            Day08.DecodeLength(line).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day08.PartOne(filename).Should().Be(expected);
        }

        [TestCase("\"\"", 6)]
        [TestCase("\"abc\"", 9)]
        [TestCase("\"aaa\\\"aaa\"", 16)]
        [TestCase("\"\\x27\"", 11)]
        public void TestEncode(string str, int expected)
        {
            Day08.EncodeLength(str).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day08.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 12);
            yield return new TestCaseData(PuzzleFile(DAY), 1342);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 19);
            yield return new TestCaseData(PuzzleFile(DAY), 2074);
        }
    }
}
