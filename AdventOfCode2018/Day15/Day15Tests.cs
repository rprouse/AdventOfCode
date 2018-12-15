using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day15Tests : TestBase
    {
        const int DAY = 15;

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day15.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day15.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day15.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 27730);
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 36334);
            yield return new TestCaseData(TestFile(DAY, "Test3.txt"), 39514);
            yield return new TestCaseData(TestFile(DAY, "Test4.txt"), 27755);
            yield return new TestCaseData(TestFile(DAY, "Test5.txt"), 28944);
            yield return new TestCaseData(TestFile(DAY, "Test6.txt"), 18740);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
