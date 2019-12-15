using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day15Tests : TestBase
    {
        const int DAY = 15;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day15.PartOne(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day15.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }
    }
}
