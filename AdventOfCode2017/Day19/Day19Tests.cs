using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day19Tests : TestBase
    {
        const int DAY = 19;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, string expected)
        {
            Assert.That(Day19.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, string expected)
        {
            Assert.That(Day19.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), "ABCDEF");
            yield return new TestCaseData(PuzzleFile(DAY), "KGPTMEJVS");
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), "");
            yield return new TestCaseData(PuzzleFile(DAY), "");
        }
    }
}
