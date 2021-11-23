using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2015
{
    public class Day10Tests : TestBase
    {
        const int DAY = 10;

        [TestCase( "1", "11" )]
        [TestCase( "11", "21" )]
        [TestCase( "21", "1211" )]
        [TestCase( "1211", "111221" )]
        [TestCase( "111221", "312211" )]
        public void TestLookAndSay(string input, string expected)
        {
            Day10.LookAndSay(input).Should().Be(expected);
        }

        [Test]
        public void TestPartOne()
        {
            Day10.PartOne("1321131112", 40).Should().Be(492982);
        }

        [Test]
        public void TestPartTwo()
        {
            Day10.PartOne("1321131112", 50).Should().Be(492982);
        }
    }
}
