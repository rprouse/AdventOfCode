using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2015
{
    public class Day14Tests : TestBase
    {
        const int DAY = 14;

        [TestCase("Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.", 1120)]
        [TestCase("Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.", 1056)]
        public void TestDistanceRaced(string text, int expected)
        {
            Day14.RaceForSeconds(text, 1000).Should().Be(expected);
        }

        [Test]
        public void TestPartOne()
        {
            Day14.PartOne(PuzzleFile(DAY)).Should().Be(2655);
        }

        [Test]
        public void TestPartTwo()
        {
            Day14.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }
    }
}
