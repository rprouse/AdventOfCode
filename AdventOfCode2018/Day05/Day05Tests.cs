using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day05Tests : TestBase
    {
        const int DAY = 05;

        [TestCase('a', 'a', false)]
        [TestCase('A', 'A', false)]
        [TestCase('a', 'A', true)]
        [TestCase('A', 'a', true)]
        [TestCase('a', 'B', false)]
        [TestCase('A', 'b', false)]
        public void CanFindPairs(char a, char b, bool expected)
        {
            Assert.That(Day05.IsPair(a, b), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day05.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day05.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 10);
            yield return new TestCaseData(PuzzleFile(DAY), 11476);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 4);
            yield return new TestCaseData(PuzzleFile(DAY), 5446).Ignore("Very slow"); ;
        }
    }
}
