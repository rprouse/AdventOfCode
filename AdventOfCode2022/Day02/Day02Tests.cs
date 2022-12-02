using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2022;

[Parallelizable(ParallelScope.All)]
public class Day02Tests : TestBase
{
    const int DAY = 02;

    [Test]
    public void TestPartTwo()
    {
        Day02.PartTwo(PuzzleFile(DAY)).Should().Be(0);
    }

    [TestCase('A', 1)]
    [TestCase('B', 2)]
    [TestCase('C', 3)]
    public void CanScoreChoice(char choice, int expected)
    {
        Day02.ChoiceScore(choice).Should().Be(expected);
    }

    [TestCase("A Y", 8)]
    [TestCase("B X", 1)]
    [TestCase("C Z", 6)]
    public void CanScorePartOne(string text, int expected)
    {
        Day02.Score(text).Should().Be(expected);
    }

    [TestCase("", 0, Ignore = "If Needed")]
    public void TestCasePartTwo(string text, int expected)
    {
        Day02.PartTwo(text).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day02.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day02.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 15);
        yield return new TestCaseData(PuzzleFile(DAY), 11063);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 0);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
