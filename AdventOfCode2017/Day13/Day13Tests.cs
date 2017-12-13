using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day13Tests : TestBase
    {
        const int DAY = 13;

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
