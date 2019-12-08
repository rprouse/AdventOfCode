using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day08Tests : TestBase
    {
        const int DAY = 08;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int width, int height, int expected)
        {
            Assert.That(Day08.PartOne(filename, width, height), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int width, int height, string expected)
        {
            Assert.That(Day08.PartTwo(filename, width, height), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 3, 2, 1);
            yield return new TestCaseData(PuzzleFile(DAY), 25, 6, 1360);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 2, 2, "01\r\n10\r\n");
            yield return new TestCaseData(PuzzleFile(DAY), 25, 6, "1111011100100100110011100\r\n1000010010100101001010010\r\n1110010010100101001010010\r\n1000011100100101111011100\r\n1000010000100101001010100\r\n1000010000011001001010010\r\n");
        }
    }
}
