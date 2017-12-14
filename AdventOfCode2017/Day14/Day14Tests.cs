using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day14Tests : TestBase
    {
        const int DAY = 14;

        [TestCase("flqrgnkx", 8108)]
        [TestCase("hwlqcszp", 8304)]
        public void TestPartOne(string hash, int expected)
        {
            Assert.That(Day14.PartOne(hash), Is.EqualTo(expected));
        }

        [TestCase("flqrgnkx", 8108)]
        [TestCase("hwlqcszp", 0)]
        public void TestPartTwo(string hash, int expected)
        {
            Assert.That(Day14.PartTwo(hash), Is.EqualTo(expected));
        }


        [TestCase("00", 0)]
        [TestCase("01", 1)]
        [TestCase("0e", 3)]
        [TestCase("0f", 4)]
        [TestCase("a0c20170", 9)]
        public void CanCountBits(string hash, int expected)
        {
            Assert.That(Day14.CountBits(hash), Is.EqualTo(expected));
        }
    }
}
