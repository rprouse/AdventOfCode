using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day13Tests : TestBase
    {
        const int DAY = 13;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day13.PartOne(filename).Should().Be(expected);
        }

        [TestCase("17,x,13,19", 3417L)]
        [TestCase("67,7,59,61", 754018L)]
        [TestCase("7,13,x,x,59,x,31,19", 1068781L)]
        [TestCase("67,x,7,59,61", 779210L)]
        [TestCase("67,7,x,59,61", 1261476L)]
        [TestCase("1789,37,47,1889", 1202161486L)]
        public void TestFirstCommonTime(string busses, long expected)
        {
            Day13.FirstCommonTime(busses).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, long expected)
        {
            Day13.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 295);
            yield return new TestCaseData(PuzzleFile(DAY), 5257);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 1068781);
            yield return new TestCaseData(PuzzleFile(DAY), 538703333547789L);
        }
    }
}
