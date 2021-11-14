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

        [TestCase("qjhvhtzxzqqjkmpb", true)]
        [TestCase("xxyxx", true)]
        [TestCase("uurcxstgmygtbstg", false)]
        [TestCase("ieodomkazucvgmuy", false)]
        public void TestNaughtyOrNiceV2(string str, bool nice)
        {
            Day05.NaughtyOrNiceV2(str).Should().Be(nice);
        }

        [TestCase("xyxy", true)]
        [TestCase("aabcdefgaa", true)]
        [TestCase("aaa", false)]
        [TestCase("qjhvhtzxzqqjkmpb", true)]
        [TestCase("xxyxx", true)]
        [TestCase("abcdef", false)]
        [TestCase("lksdfj", false)]
        public void TestContainsTwoPairs(string str, bool expected)
        {
            Day05.ContainsTwoPairs(str).Should().Be(expected);
        }

        [TestCase("xyx", true)]
        [TestCase("abcdefeghi", true)]
        [TestCase("aaa", true)]
        [TestCase("qjhvhtzxzqqjkmpb", true)]
        [TestCase("xxyxx", true)]
        [TestCase("abcdef", false)]
        [TestCase("lksdfj", false)]
        public void TestContainsRepeat(string str, bool expected)
        {
            Day05.ContainsRepeat(str).Should().Be(expected);
        }

        [Test]
        public void TestPartTwo()
        {
            Day05.PartTwo(PuzzleFile(DAY)).Should().Be(55);
        }
    }
}
