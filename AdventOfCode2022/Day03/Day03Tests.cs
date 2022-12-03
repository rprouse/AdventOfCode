using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022;

[Parallelizable(ParallelScope.All)]
public class Day03Tests : TestBase
{
    const int DAY = 03;

    [TestCase('p', 16)]
    [TestCase('L', 38)]
    [TestCase('P', 42)]
    [TestCase('v', 22)]
    public void TestPriority(char c, int expected)
    {
        c.Priority().Should().Be(expected);
    }

    [TestCase("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
    [TestCase("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
    [TestCase("PmmdzqPrVvPwwTWBwg", 'P')]
    [TestCase("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
    [TestCase("ttgJtRGJQctTZtZT", 't')]
    [TestCase("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
    public void TestCommonLetter(string text, char expected)
    {
        text.Common().Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day03.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day03.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 157);
        yield return new TestCaseData(PuzzleFile(DAY), 7908);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 70);
        yield return new TestCaseData(PuzzleFile(DAY), 2838);
    }
}
