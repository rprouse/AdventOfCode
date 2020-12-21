using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day19Tests : TestBase
    {
        const int DAY = 19;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day19.PartOne(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 2);
            yield return new TestCaseData(PuzzleFile(DAY), 176);
            yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 3);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day19.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 12);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
