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

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string walk, int expected)
        {
            Assert.That(Day01.PartTwo(walk), Is.EqualTo(expected));
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
            yield return new TestCaseData("R8, R4, R4, R8", 4);
            yield return new TestCaseData(PuzzleFile(DAY).ReadFirstLine(), 110);
        }
    }
}
