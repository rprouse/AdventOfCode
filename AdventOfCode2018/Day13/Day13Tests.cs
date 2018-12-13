using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day13Tests : TestBase
    {
        const int DAY = 13;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expectedX, int expectedY)
        {
            (int x, int y) = Day13.PartOne(filename);
            Assert.That(x, Is.EqualTo(expectedX));
            Assert.That(y, Is.EqualTo(expectedY));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expectedX, int expectedY)
        {
            (int x, int y) = Day13.PartTwo(filename);
            Assert.That(x, Is.EqualTo(expectedX));
            Assert.That(y, Is.EqualTo(expectedY));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 7, 3);
            yield return new TestCaseData(PuzzleFile(DAY), 64, 57);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 6, 4);
            yield return new TestCaseData(PuzzleFile(DAY), 136, 8);
        }
    }
}
