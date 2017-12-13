using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day13Tests : TestBase
    {
        const int DAY = 13;

        [TestCase(0, true)]
        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(3, false)]
        [TestCase(4, false)]
        [TestCase(5, false)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        public void TestTheorum(int step, bool expected)
        {
            var actual = step % ((4-1) * 2) == 0;
            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            string[] lines = File.ReadAllLines(filename);
            Assert.That(Day13.PartOne(lines), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            string[] lines = File.ReadAllLines(filename);
            Assert.That(Day13.PartTwo(lines), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 24);
            yield return new TestCaseData(PuzzleFile(DAY), 1844);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 10);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
