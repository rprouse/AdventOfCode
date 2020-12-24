using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day23Tests : TestBase
    {
        const int DAY = 23;

        [TestCase("389125467", 10, "92658374")]
        [TestCase("389125467", 100, "67384529")]
        [TestCase("247819356", 100, "76385429")]
        public void TestPartOne(string cups, int moves, string expected)
        {
            Day23.PartOne(cups, moves).Should().Be(expected);
        }

        [TestCase("389125467", 149245887792L, Ignore = "Too long")]
        [TestCase("247819356", 0L, Ignore = "Too long")]
        public void TestPartTwo(string cups, long expected)
        {
            Day23.PartTwo(cups).Should().Be(expected);
        }
    }
}
