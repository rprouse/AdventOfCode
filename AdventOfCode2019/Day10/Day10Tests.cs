using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day10Tests : TestBase
    {
        const int DAY = 10;

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day10.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day10.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day10.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY, "Test01.txt"), 8);
            yield return new TestCaseData(TestFile(DAY, "Test02.txt"), 33);
            yield return new TestCaseData(TestFile(DAY, "Test03.txt"), 35);
            yield return new TestCaseData(TestFile(DAY, "Test04.txt"), 41);
            yield return new TestCaseData(TestFile(DAY, "Test05.txt"), 210);
            yield return new TestCaseData(PuzzleFile(DAY), 326);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
