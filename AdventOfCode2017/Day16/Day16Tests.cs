using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day16Tests : TestBase
    {
        const int DAY = 16;

        [Test]
        public void TestPartOne()
        {
            string str = File.ReadAllText(PuzzleFile(DAY));
            Assert.That(Day16.PartOne(str), Is.EqualTo(0));
        }

        [Test]
        public void TestPartTwo()
        {
            string str = File.ReadAllText(PuzzleFile(DAY));
            Assert.That(Day16.PartTwo(str), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            string str = File.ReadAllText(filename);
            Assert.That(Day16.PartOne(str), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            string str = File.ReadAllText(filename);
            Assert.That(Day16.PartTwo(str), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
