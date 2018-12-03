using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day03Tests : TestBase
    {
        const int DAY = 03;

        [TestCase("#1 @ 1,3: 4x4", 1, 1, 3, 4, 4)]
        [TestCase("#2 @ 3,1: 4x4", 2, 3, 1, 4, 4)]
        [TestCase("#3 @ 5,5: 2x2", 3, 5, 5, 2, 2)]
        public void CanParseClaim(string claimStr, int number, int x, int y, int w, int h)
        {
            var claim = new Day03.Claim(claimStr);
            Assert.That(claim.Number, Is.EqualTo(number));
            Assert.That(claim.X, Is.EqualTo(x));
            Assert.That(claim.Y, Is.EqualTo(y));
            Assert.That(claim.W, Is.EqualTo(w));
            Assert.That(claim.H, Is.EqualTo(h));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day03.PartOne(filename), Is.EqualTo(expected));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day03.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day03.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 4);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
