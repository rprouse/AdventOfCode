using System.Collections;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day16Tests : TestBase
    {
        const int DAY = 16;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int phases, int expected)
        {
            Assert.That(Day16.PartOne(filename, phases), Is.EqualTo(expected));
        }

        [Test]
        public void CanFindLastDigit([Values(123456, -123456)]int num)
        {
            Assert.That(Day16.LastDigit(num), Is.EqualTo(6));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, long multiplier, int expected)
        {
            Assert.That(Day16.PartTwo(filename, multiplier), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 4, 01029498);
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 100, 24176176);
            yield return new TestCaseData(TestFile(DAY, "Test3.txt"), 100, 73745418);
            yield return new TestCaseData(TestFile(DAY, "Test4.txt"), 100, 52432133);
            yield return new TestCaseData(PuzzleFile(DAY), 100, 49254779).Ignore("Slow");
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY, "Test5.txt"), 10000, 84462026).Ignore("Slow");
            yield return new TestCaseData(TestFile(DAY, "Test6.txt"), 10000, 78725270).Ignore("Slow");
            yield return new TestCaseData(TestFile(DAY, "Test7.txt"), 10000, 53553731).Ignore("Slow");
            yield return new TestCaseData(PuzzleFile(DAY), 10000, 0).Ignore("Unsolved with brute force");
        }
    }
}
