using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day10Tests : TestBase
    {
        const int DAY = 10;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day10.PartOne(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, long expected)
        {
            Day10.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 35);
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 220);
            yield return new TestCaseData(PuzzleFile(DAY), 2775);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 8L);
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 19208L);
            yield return new TestCaseData(PuzzleFile(DAY), 518344341716992L);
        }
    }
}
