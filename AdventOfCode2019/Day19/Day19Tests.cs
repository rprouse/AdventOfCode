using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day19Tests : TestBase
    {
        const int DAY = 19;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day19.PartOne(PuzzleFile(DAY)), Is.EqualTo(129));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day19.PartTwo(PuzzleFile(DAY)), Is.EqualTo(14040699));
        }
    }
}
