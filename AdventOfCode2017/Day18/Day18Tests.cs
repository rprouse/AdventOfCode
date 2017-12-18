using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day18Tests : TestBase
    {
        const int DAY = 18;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, long expected)
        {
            string[] str = File.ReadAllLines(filename);
            Assert.That(Day18.PartOne(str), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, long expected)
        {
            string[] str = File.ReadAllLines(filename);
            Assert.That(Day18.PartTwo(str), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 4);
            yield return new TestCaseData(PuzzleFile(DAY), 7071);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
