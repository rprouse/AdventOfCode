using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day14Tests : TestBase
    {
        const int DAY = 14;

        [TestCase(9, "5158916779")]
        [TestCase(5, "0124515891")]
        [TestCase(18, "9251071085")]
        [TestCase(2018, "5941429882")]
        [TestCase(293801, "3147574107")]
        public void TestPartOne(int recipes, string expected)
        {
            Assert.That(Day14.PartOne(recipes), Is.EqualTo(expected));
        }

        [TestCase(710101, 1)]
        [TestCase(515891, 9)]
        [TestCase(012451, 5)]
        [TestCase(925107, 18)]
        [TestCase(594142, 2018)]
        [TestCase(293801, 20280190, Ignore = "Takes 4 sec")]
        public void TestPartTwo(int score, int expected)
        {
            Assert.That(Day14.PartTwo(score), Is.EqualTo(expected));
        }

        [TestCase(1, 2)]
        [TestCase(2, 9)]
        [TestCase(3, 3)]
        [TestCase(4, 8)]
        [TestCase(5, 0)]
        [TestCase(6, 1)]
        public void CanGetDigit(int d, int expected)
        {
            Assert.That(Day14.GetDigit(d, 293801), Is.EqualTo(expected));
        }
    }
}
