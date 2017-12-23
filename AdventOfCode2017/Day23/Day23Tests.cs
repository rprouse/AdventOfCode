using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day23Tests : TestBase
    {
        const int DAY = 23;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day23.PartOne(PuzzleFile(DAY)), Is.EqualTo(4225));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day23.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }
    }
}
