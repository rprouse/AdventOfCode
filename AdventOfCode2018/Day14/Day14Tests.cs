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

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day14.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }
    }
}
