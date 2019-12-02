using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day02Tests : TestBase
    {
        const int DAY = 02;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day02.PartOne(PuzzleFile(DAY)), Is.EqualTo(3716250));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day02.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(int[] codes, int[] expected)
        {
            Assert.That(Day02.RunIntcodeProgram(codes), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(new int[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 }, new int[] { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 });
            yield return new TestCaseData(new int[] { 1, 0, 0, 0, 99 }, new int[] { 2, 0, 0, 0, 99 });
            yield return new TestCaseData(new int[] { 2, 3, 0, 3, 99 }, new int[] { 2, 3, 0, 6, 99 });
            yield return new TestCaseData(new int[] { 2, 4, 4, 5, 99, 0 }, new int[] { 2, 4, 4, 5, 99, 9801 });
            yield return new TestCaseData(new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new int[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 });
        }
    }
}
