using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;
using System.Drawing;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day12Tests : TestBase
    {
        const int DAY = 12;

        [Test]
        public void TestPartTwoTurnRight()
        {
            Point point = new Point(10, -4);
            point = Day12.TurnRight(point, 90);
            point.X.Should().Be(4);
            point.Y.Should().Be(10);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day12.PartOne(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day12.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 25);
            yield return new TestCaseData(PuzzleFile(DAY), 1294);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 286);
            yield return new TestCaseData(PuzzleFile(DAY), 20592);
        }
    }
}
