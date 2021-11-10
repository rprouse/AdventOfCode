using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2015
{
    public class Day05Tests : TestBase
    {
        const int DAY = 05;

        [TestCase("ugknbfddgicrmopn", true)]
        [TestCase("aaa", true)]
        [TestCase("jchzalrnumimnmhp", false)]
        [TestCase("haegwjzuvuyypxyu", false)]
        [TestCase("dvszwmarrgswjxmb", false)]
        public void TestNaughtyOrNice(string str, bool nice)
        {
            Day05.NaughtyOrNice(str).Should().Be(nice);
        }

        [Test]
        public void TestPartOne()
        {
            Day05.PartOne(PuzzleFile(DAY)).Should().Be(255);
        }

        [Test]
        public void TestPartTwo()
        {
            Day05.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }
    }
}
