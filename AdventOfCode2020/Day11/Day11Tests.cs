using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day11Tests : TestBase
    {
        const int DAY = 11;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day11.PartOne(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day11.PartTwo(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestVisibleSeats))]
        public void TestPartTwoVisibleSeats(string filename, int x, int y, int expected)
        {
            var area = new WaitingAreaTwo(filename);
            area.VisibleSeats(x, y).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 37);
            yield return new TestCaseData(PuzzleFile(DAY), 2277);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 26);
            yield return new TestCaseData(PuzzleFile(DAY), 2066);
        }

        public static IEnumerable TestVisibleSeats()
        {
            yield return new TestCaseData(TestFile(DAY, "Test2a.txt"), 1, 1, 0);
            yield return new TestCaseData(TestFile(DAY, "Test2b.txt"), 3, 3, 0);
            yield return new TestCaseData(TestFile(DAY, "Test2c.txt"), 3, 4, 8);
            yield return new TestCaseData(TestFile(DAY, "Test2d.txt"), 3, 0, 0);
        }
    }
}
