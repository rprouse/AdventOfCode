using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day01Tests : TestBase
    {
        const int DAY = 01;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string walk, int expected)
        {
            Assert.That(Day01.PartOne(walk), Is.EqualTo(expected));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day01.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day01.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData("R2, L3", 5);
            yield return new TestCaseData("R2, R2, R2", 2);
            yield return new TestCaseData("R5, L5, R5, R3", 12);
            yield return new TestCaseData(PuzzleFile(DAY).ReadFirstLine(), 161);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
