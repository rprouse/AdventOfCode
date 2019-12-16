using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2015
{
    public class Day01Tests : TestBase
    {
        const int DAY = 01;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day01.PartOne(PuzzleFile(DAY)), Is.EqualTo(138));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day01.PartTwo(PuzzleFile(DAY)), Is.EqualTo(1771));
        }

        [TestCase("(())", 0)]
        [TestCase("()()", 0)]
        [TestCase("(((", 3)]
        [TestCase("(()(()(", 3)]
        [TestCase("))(((((", 3)]
        [TestCase("())", -1)]
        [TestCase("))(", -1)]
        [TestCase(")))", -3)]
        [TestCase(")())())", -3)]
        public void TestPartOne(string directions, int expected)
        {
            Assert.That(Day01.CalculateFloor(directions), Is.EqualTo(expected));
        }

        [TestCase(")", 1)]
        [TestCase("()())", 5)]
        public void TestPartTwo(string directions, int expected)
        {
            Assert.That(Day01.FirstBasementDirection(directions), Is.EqualTo(expected));
        }
    }
}
