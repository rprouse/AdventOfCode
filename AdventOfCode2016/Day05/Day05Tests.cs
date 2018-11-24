using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day05Tests : TestBase
    {
        const int DAY = 05;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day05.PartOne(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day05.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day05.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day05.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
