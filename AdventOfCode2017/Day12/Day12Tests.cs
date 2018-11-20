using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day12Tests : TestBase
    {
        const int DAY = 12;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            var lines = File.ReadLines(filename);
            Assert.That(Day12.PartOne(lines), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            var lines = File.ReadLines(filename);
            Assert.That(Day12.PartTwo(lines), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 6);
            yield return new TestCaseData(PuzzleFile(DAY), 175);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 2);
            yield return new TestCaseData(PuzzleFile(DAY), 213);
        }
    }
}
