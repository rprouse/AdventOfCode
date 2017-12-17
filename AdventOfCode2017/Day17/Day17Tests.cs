using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day17Tests : TestBase
    {
        const int DAY = 17;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day17.PartOne(343), Is.EqualTo(1914));
        }

        [Test]
        public void TestPartOneExample()
        {
            Assert.That(Day17.PartOne(3), Is.EqualTo(638));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day17.PartTwo(343), Is.EqualTo(0));
        }
    }
}
