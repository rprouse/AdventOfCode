using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2015
{
    public class Day07Tests : TestBase
    {
        const int DAY = 07;

        [Test]
        public void TestPartOne()
        {
            Day07.PartOne(PuzzleFile(DAY), "a").Should().Be(16076);
        }

        [TestCase("d", 72)]
        [TestCase("e", 507)]
        [TestCase("f", 492)]
        [TestCase("g", 114)]
        [TestCase("h", 65412)]
        [TestCase("i", 65079)]
        [TestCase("x", 123)]
        [TestCase("y", 456)]
        public void TestDataPartOne(string wire, int expected)
        {
            Day07.PartOne(TestFile(DAY), wire).Should().Be((ushort)expected);
        }

        [Test]
        public void TestPartTwo()
        {
            Day07.PartOne(PuzzleFile(DAY, "Data2.txt"), "a").Should().Be(2797);
        }
    }
}
