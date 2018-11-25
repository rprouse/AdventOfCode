using System.Collections;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day06Tests : TestBase
    {
        const int DAY = 06;

        [Test]
        public void CanFindMostCommonChar()
        {
            Assert.That(Day06.MostCommonChar(TestFile(DAY).ReadAllLines(), 0), Is.EqualTo('e'));
        }

        [Test]
        public void CanFindLeastCommonChar()
        {
            Assert.That(Day06.LeastCommonChar(TestFile(DAY).ReadAllLines(), 0), Is.EqualTo('a'));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, string expected)
        {
            Assert.That(Day06.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, string expected)
        {
            Assert.That(Day06.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), "easter");
            yield return new TestCaseData(PuzzleFile(DAY), "dzqckwsd");
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), "advent");
            yield return new TestCaseData(PuzzleFile(DAY), "lragovly");
        }
    }
}
