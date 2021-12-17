using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;
using System.Linq;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day16Tests : TestBase
{
    const int DAY = 16;

    [Test]
    public void TestPartOne()
    {
        Day16.PartOne(PuzzleFile(DAY)).Should().Be(0);
    }

    [Test]
    public void TestPartTwo()
    {
        Day16.PartTwo(PuzzleFile(DAY)).Should().Be(0);
    }

    [TestCase("01", 0, Ignore = "If Needed")]
    public void TestCasePartOne(string text, int expected)
    {
        Day16.PartOne(text).Should().Be(expected);
    }

    [TestCase("", 0, Ignore = "If Needed")]
    public void TestCasePartTwo(string text, int expected)
    {
        Day16.PartTwo(text).Should().Be(expected);
    }

    [TestCaseSource(nameof(ParseHexData))]
    public void TestParseHex(string line, byte[] expected)
    {
        Day16.ParseHex(line).Should().BeEquivalentTo(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day16.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable ParseHexData()
    {
        yield return new TestCaseData("F", new byte[] { 0xF0 });
        yield return new TestCaseData("01", new byte[] { 0x01 } );
        yield return new TestCaseData("0123456789ABCDEF", new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF });
        yield return new TestCaseData("0123456789ABCDEF5", new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0x50 });
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
