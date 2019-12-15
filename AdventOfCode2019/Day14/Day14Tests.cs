using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day14Tests : TestBase
    {
        const int DAY = 14;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, long expected)
        {
            Assert.That(Day14.PartOne(filename), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, long expected)
        {
            Assert.That(Day14.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 31);
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 165);
            yield return new TestCaseData(TestFile(DAY, "Test3.txt"), 13312);
            yield return new TestCaseData(TestFile(DAY, "Test4.txt"), 180697);
            yield return new TestCaseData(TestFile(DAY, "Test5.txt"), 2210736);
            yield return new TestCaseData(PuzzleFile(DAY), 337075);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY, "Test3.txt"), 82892753);
            yield return new TestCaseData(TestFile(DAY, "Test4.txt"), 5586022);
            yield return new TestCaseData(TestFile(DAY, "Test5.txt"), 460664);
            yield return new TestCaseData(PuzzleFile(DAY), 5194174);
        }
    }
}
