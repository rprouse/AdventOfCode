using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day09Tests : TestBase
    {
        [TestCase(9, 25, 32)]
        [TestCase(10, 1618, 8317)]
        [TestCase(13, 7999, 146373)]
        [TestCase(17, 1104, 2764)]
        [TestCase(21, 6111, 54718)]
        [TestCase(30, 5807, 37305)]
        [TestCase(491, 71058, 361466)]
        [TestCase(491, 7105800, 2945918550)]
        public void TestPartOne(int players, int highMarble, long expectedScore)
        {
            Assert.That(Day09.PartOne(players, highMarble), Is.EqualTo(expectedScore));
        }
    }
}
