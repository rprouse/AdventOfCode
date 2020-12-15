using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2020
{
    public class Day15Tests : TestBase
    {
        const int DAY = 15;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(int[] numbers, int expected)
        {
            Day15.LastSpoken(numbers, 2020).Should().Be(expected);
        }

        [Explicit("About 1.5 sec each")]
        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(int[] numbers, int expected)
        {
            Day15.LastSpoken(numbers, 30000000).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(new[] { 0, 3, 6 }, 436);
            yield return new TestCaseData(new[] { 1, 3, 2 }, 1);
            yield return new TestCaseData(new[] { 2, 1, 3 }, 10);
            yield return new TestCaseData(new[] { 1, 2, 3 }, 27);
            yield return new TestCaseData(new[] { 2, 3, 1 }, 78);
            yield return new TestCaseData(new[] { 3, 2, 1 }, 438);
            yield return new TestCaseData(new[] { 3, 1, 2 }, 1836);
            yield return new TestCaseData(new[] { 1, 17, 0, 10, 18, 11, 6 }, 595);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(new[] { 0, 3, 6 }, 175594);
            yield return new TestCaseData(new[] { 1, 3, 2 }, 2578);
            yield return new TestCaseData(new[] { 2, 1, 3 }, 3544142);
            yield return new TestCaseData(new[] { 1, 2, 3 }, 261214);
            yield return new TestCaseData(new[] { 2, 3, 1 }, 6895259);
            yield return new TestCaseData(new[] { 3, 2, 1 }, 18);
            yield return new TestCaseData(new[] { 3, 1, 2 }, 362);
            yield return new TestCaseData(new[] { 1, 17, 0, 10, 18, 11, 6 }, 1708310);
        }
    }
}
