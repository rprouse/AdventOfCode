using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2015
{
    public class Day06Tests : TestBase
    {
        const int DAY = 06;

        [Test]
        public void TestPartOne()
        {
            Day06.PartOne(PuzzleFile(DAY)).Should().Be(377891);
        }

        [Test]
        public void TestPartTwo()
        {
            Day06.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }
    }
}
