using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day02Tests : TestBase
    {
        const int DAY = 02;

        [TestCase("abcdef", false)]
        [TestCase("bababc", true)]
        [TestCase("abbcde", true)]
        [TestCase("abcccd", false)]
        [TestCase("aabcdd", true)]
        [TestCase("abcdee", true)]
        [TestCase("ababab", false)]
        public void CanCountPairs(string line, bool expected)
        {
            Assert.That(Day02.ContainsPair(line), Is.EqualTo(expected));
        }

        [TestCase("abcdef", false)]
        [TestCase("bababc", true)]
        [TestCase("abbcde", false)]
        [TestCase("abcccd", true)]
        [TestCase("aabcdd", false)]
        [TestCase("abcdee", false)]
        [TestCase("ababab", true)]
        public void CanCountTriples(string line, bool expected)
        {
            Assert.That(Day02.ContainsTriple(line), Is.EqualTo(expected));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day02.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day02.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day02.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 12);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
