using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day14Tests : TestBase
    {
        const int DAY = 14;

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day14.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day14.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day14.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 31);
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 165);
            yield return new TestCaseData(TestFile(DAY, "Test3.txt"), 13312);
            yield return new TestCaseData(TestFile(DAY, "Test4.txt"), 180697);
            yield return new TestCaseData(TestFile(DAY, "Test5.txt"), 2210736);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
