using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day11Tests : TestBase
    {
        const int DAY = 11;

        [TestCase(3, 5, 8, 4)]
        [TestCase(122, 79, 57, -5)]
        [TestCase(217, 196, 39, 0)]
        [TestCase(101, 153, 71, 4)]
        public void CanCalculatePower(int x, int y, int serial, int expected)
        {
            Assert.That(Day11.CalculatePower(x, y, serial), Is.EqualTo(expected));
        }

        [TestCase(18, 33, 45)]
        [TestCase(42, 21, 61)]
        [TestCase(4842, 20, 83)]
        public void TestPartOne(int serial, int expectedX, int expectedY)
        {
            (int x, int y) = Day11.PartOne(serial);
            Assert.That(x, Is.EqualTo(expectedX));
            Assert.That(y, Is.EqualTo(expectedY));
        }

        [Test]
        public void TestPartTwo()
        {
        }
    }
}
