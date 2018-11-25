using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    [Explicit("These take about a minute to run")]
    [Parallelizable(ParallelScope.All)]
    public class Day05Tests : TestBase
    {
        const int DAY = 05;

        [TestCase("abc", "18f47a30")]
        [TestCase("wtnhxymk", "2414bc77")]
        public void TestPartOne(string door, string password)
        {
            Assert.That(Day05.PartOne(door), Is.EqualTo(password));
        }

        [TestCase("abc", "05ace8e3")]
        [TestCase("wtnhxymk", "437e60fc")]
        public void TestPartTwo(string door, string password)
        {
            Assert.That(Day05.PartTwo(door), Is.EqualTo(password));
        }
    }
}
