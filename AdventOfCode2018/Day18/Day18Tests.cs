using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day18Tests : TestBase
    {
        const int DAY = 18;

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day18.PartTwo(PuzzleFile(DAY)), Is.EqualTo(203138));
        }

        [TestCase(10, 6)]
        [TestCase(20, 4)]
        [TestCase(15, 3)]
        [TestCase(16, 4)]
        [TestCase(17, 5)]
        [TestCase(18, 6)]
        public void CanFindIndex(int max, int expected)
        {
            Assert.That(Day18.FindIndex(max, 3, 7), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day18.PartOne(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 1147);
            yield return new TestCaseData(PuzzleFile(DAY), 594712);
        }
    }
}
