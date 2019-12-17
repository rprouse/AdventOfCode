using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day11Tests : TestBase
    {
        const int DAY = 11;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day11.PartOne(PuzzleFile(DAY)), Is.EqualTo(2016));
        }

        [Test]
        public void TestPartTwo()
        {
            // The real answer is in the output image, RAPRCBPH
            Assert.That(Day11.PartTwo(PuzzleFile(DAY)), Is.EqualTo(249));
        }
    }
}
