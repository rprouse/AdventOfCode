using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day09Tests : TestBase
    {
        const int DAY = 09;

        [TestCaseSource(nameof(DecompressedData))]
        public void TestDecompression(string compressed, string decompressed)
        {
            Assert.That(Day09.Decompress(compressed), Is.EqualTo(decompressed));
        }

        [TestCaseSource(nameof(CompressedLengthData))]
        public void TestUncompressedLength(string compressed, int expected)
        {
            Assert.That(Day09.Decompress(compressed).Length, Is.EqualTo(expected));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day09.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day09.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable DecompressedData()
        {
            yield return new TestCaseData("ADVENT", "ADVENT");
            yield return new TestCaseData("A(1x5)BC", "ABBBBBC");
            yield return new TestCaseData("(3x3)XYZ", "XYZXYZXYZ");
            yield return new TestCaseData("A(2x2)BCD(2x2)EFG", "ABCBCDEFEFG");
            yield return new TestCaseData("(6x1)(1x3)A", "(1x3)A");
            yield return new TestCaseData("X(8x2)(3x3)ABCY", "X(3x3)ABC(3x3)ABCY");
        }

        public static IEnumerable CompressedLengthData()
        {
            yield return new TestCaseData("ADVENT", 6);
            yield return new TestCaseData("A(1x5)BC", 7);
            yield return new TestCaseData("(3x3)XYZ", 9);
            yield return new TestCaseData("A(2x2)BCD(2x2)EFG", 11);
            yield return new TestCaseData("(6x1)(1x3)A", 6);
            yield return new TestCaseData("X(8x2)(3x3)ABCY", 18);
            yield return new TestCaseData(PuzzleFile(DAY).ReadFirstLine(), 152851);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
