using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2015
{
    public class Day02Tests : TestBase
    {
        const int DAY = 02;

        [TestCase(2, 3, 4, 58)]
        [TestCase(1, 1, 10, 43)]
        public void CanCalculatePaperDimensions(int l, int w, int h, int expected)
        {
            int d = Day02.CalculatePaperNeeded(l, w, h);
            Assert.That(d, Is.EqualTo(expected));
        }

        [TestCase("2x3x4", 58)]
        [TestCase("1x1x10", 43)]
        public void CanCalculatePaperDimensions(string str, int expected)
        {
            int d = Day02.CalculatePaperNeeded(str);
            Assert.That(d, Is.EqualTo(expected));
        }

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day02.PartOne(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day02.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day02.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
