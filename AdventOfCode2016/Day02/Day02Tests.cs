using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day02Tests : TestBase
    {
        const int DAY = 02;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, string expected)
        {
            Assert.That(Day02.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, string expected)
        {
            Assert.That(Day02.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), "1985");
            yield return new TestCaseData(PuzzleFile(DAY), "53255");
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), "5DB3");
            yield return new TestCaseData(PuzzleFile(DAY), "7423A");
        }
    }
}
