using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day20Tests : TestBase
    {
        const int DAY = 20;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day20.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day20.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            //yield return new TestCaseData(TestFile(DAY), 1);
            yield return new TestCaseData(PuzzleFile(DAY), 300);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData($"Day{DAY:00}\\Test2.txt", 1);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
