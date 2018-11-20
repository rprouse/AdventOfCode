using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day15Tests : TestBase
    {
        const int DAY = 15;

        [TestCase(65, 8921, 588)]
        [TestCase(873, 583, 631)]
        public void TestPartOne(int seedA, int seedB, int expected)
        {
            Assert.That(Day15.PartOne(seedA, seedB), Is.EqualTo(expected));
        }

        [Test]
        public void TestPartOneSmallRun()
        {
            Assert.That(Day15.PartOne(65, 8921, 5), Is.EqualTo(1));
        }

        [TestCase(65, 8921, 309)]
        [TestCase(873, 583, 279)]
        public void TestPartTwo(int seedA, int seedB, int expected)
        {
            Assert.That(Day15.PartTwo(seedA, seedB), Is.EqualTo(expected));
        }

        [TestCase(65, 16807, 1092455)]
        [TestCase(1092455, 16807, 1181022009)]
        [TestCase(1181022009, 16807, 245556042)]
        [TestCase(245556042, 16807, 1744312007)]
        [TestCase(1744312007, 16807, 1352636452)]
        [TestCase(8921, 48271, 430625591)]
        [TestCase(430625591, 48271, 1233683848)]
        [TestCase(1233683848, 48271, 1431495498)]
        [TestCase(1431495498, 48271, 137874439)]
        [TestCase(137874439, 48271, 285222916)]
        public void CanGenerate(int seed, int multiplier, int expected)
        {
            Assert.That(Day15.Generate(seed, multiplier), Is.EqualTo(expected));
        }

        [TestCase(1092455, 430625591, false)]
        [TestCase(1181022009, 1233683848, false)]
        [TestCase(245556042, 1431495498, true)]
        [TestCase(1744312007, 137874439, false)]
        [TestCase(1352636452, 285222916, false)]
        public void LowerBitsMatch(int a, int b, bool expected)
        {
            Assert.That(Day15.LowerBitsMatch(a, b), Is.EqualTo(expected));
        }
    }
}
