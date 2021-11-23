using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2015
{
    public class Day10Tests : TestBase
    {
        [TestCase( "1", "11" )]
        [TestCase( "11", "21" )]
        [TestCase( "21", "1211" )]
        [TestCase( "1211", "111221" )]
        [TestCase( "111221", "312211" )]
        public void TestLookAndSay(string input, string expected)
        {
            Day10.LookAndSay(input).Should().Be(expected);
        }

        [TestCase(40, 492982)]
        [TestCase(50, 6989950)]
        public void TestPartOne(int count, int expected)
        {
            Day10.PartOne("1321131112", count).Should().Be(expected);
        }
    }
}
