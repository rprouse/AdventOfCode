using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;
using System.Linq;

namespace AdventOfCode2015
{
    public class Day09Tests : TestBase
    {
        const int DAY = 09;

        [Test]
        public void CanCalculateRoutes()
        {
            var cities = Day09.GetCities(TestFile(DAY));
            var routes = Day09.Routes(cities.Keys.ToList());
            routes.Should().HaveCount(6);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day09.PartOne(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Day09.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 605);
            yield return new TestCaseData(PuzzleFile(DAY), 207);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 982);
            yield return new TestCaseData(PuzzleFile(DAY), 804);
        }
    }
}
