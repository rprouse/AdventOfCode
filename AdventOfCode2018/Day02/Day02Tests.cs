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
            Assert.That(Day02.ContainsNumberOfCharacters(line, 2), Is.EqualTo(expected));
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
            Assert.That(Day02.ContainsNumberOfCharacters(line, 3), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day02.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, string expected)
        {
            Assert.That(Day02.PartTwo(filename), Is.EqualTo(expected));
        }

        [Test]
        public void CanFindDifferenceInMatchingPair()
        {
            var lines = TestFile(DAY, "Test2.txt").ReadAllLines();
            string diff = Day02.DifferenceInMatchingPair(lines);
            Assert.That(diff, Is.EqualTo("fgij"));
        }

        [TestCase("abcde", "axcye", "ace")]
        [TestCase("fghij", "fguij", "fgij")]
        [TestCase("klmno", "pqrst", "")]
        public void CanFindDifference(string a, string b, string diff)
        {
            Assert.That(Day02.Difference(a, b), Is.EqualTo(diff));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 12);
            yield return new TestCaseData(PuzzleFile(DAY), 4940);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), "fgij");
            yield return new TestCaseData(PuzzleFile(DAY), "wrziyfdmlumeqvaatbiosngkc");
        }
    }
}
