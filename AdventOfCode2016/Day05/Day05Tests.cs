using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day05Tests : TestBase
    {
        const int DAY = 05;

        [TestCase("abc", "18f47a30")]
        [TestCase("wtnhxymk", "")]
        public void TestPartOne(string door, string password)
        {
            Assert.That(Day05.PartOne(door), Is.EqualTo(password));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day05.PartTwo(""), Is.EqualTo(""));
        }
    }
}
