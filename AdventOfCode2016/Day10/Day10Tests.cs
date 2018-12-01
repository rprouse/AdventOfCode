using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day10Tests : TestBase
    {
        const int DAY = 10;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int high, int low, int expected)
        {
            Assert.That(Day10.PartOne(filename, high, low), Is.EqualTo(expected));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day10.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day10.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 5, 2, 2);
            yield return new TestCaseData(TestFile(DAY), 3, 2, 1);
            yield return new TestCaseData(TestFile(DAY), 5, 3, 0);
            yield return new TestCaseData(PuzzleFile(DAY), 61, 17, 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
