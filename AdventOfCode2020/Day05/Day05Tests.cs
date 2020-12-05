using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day05Tests : TestBase
    {
        const int DAY = 05;

        [TestCase("FBFBBFFRLR", 44, 5)]
        [TestCase("BFFFBBFRRR", 70, 7)]
        [TestCase("FFFBBBFRRR", 14, 7)]
        [TestCase("BBFFBBFRLL", 102, 4)]
        public void CanParseBoardingPass(string pass, int row, int col)
        {
            var seat = Day05.GetSeat(pass);
            seat.row.Should().Be(row);
            seat.col.Should().Be(col);
        }

        [TestCase("FBFBBFFRLR", 357)]
        [TestCase("BFFFBBFRRR", 567)]
        [TestCase("FFFBBBFRRR", 119)]
        [TestCase("BBFFBBFRLL", 820)]
        public void CanGetSeatId(string pass, int expected)
        {
            var id = Day05.GetSeatId(pass);
            id.Should().Be(expected);
        }

        [Test]
        public void TestPartOne()
        {
            Day05.PartOne(PuzzleFile(DAY)).Should().Be(828);
        }

        [Test]
        public void TestPartTwo()
        {
            Day05.PartTwo(PuzzleFile(DAY)).Should().Be(565);
        }
    }
}
