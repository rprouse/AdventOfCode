using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day06Tests : TestBase
    {
        const int DAY = 06;

        [Test]
        public void CanParse()
        {
            (int x, int y) = Day06.Parse("266, 253");
            Assert.That(x, Is.EqualTo(266));
            Assert.That(y, Is.EqualTo(253));
        }

        [TestCase(0, 0, 0)]
        [TestCase(5, 0, -1)]
        [TestCase(5, 2, 4)]
        [TestCase(3, 5, 3)]
        [TestCase(5, 8, 4)]
        [TestCase(6, 8, 5)]
        public void CanDetermineClosestTo(int x, int y, int expected)
        {
            (int, int)[] coords = Day06.GetCoordinates(TestFile(DAY));
            int closest = Day06.ClosestTo(coords, x, y);
            Assert.That(closest, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day06.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int lessThan, int expected)
        {
            Assert.That(Day06.PartTwo(filename, lessThan), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 17);
            yield return new TestCaseData(PuzzleFile(DAY), 5532);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 32, 16);
            yield return new TestCaseData(PuzzleFile(DAY), 10000, 36216);
        }
    }
}
