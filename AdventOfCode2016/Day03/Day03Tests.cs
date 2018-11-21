using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day03Tests : TestBase
    {
        const int DAY = 03;

        [TestCase("    5   10   25", 5, 10, 25)]
        [TestCase("  541  588  421", 541, 588, 421)]
        [TestCase("  827  272  126", 827, 272, 126)]
        [TestCase("  660  514  367", 660, 514, 367)]
        [TestCase("   39  703  839", 39, 703, 839)]
        [TestCase("  229  871    3", 229, 871, 3)]
        public void CanParseTriangle(string input, int a, int b, int c)
        {
            (int a1, int b1, int c1) = Day03.ParseTriangle(input);
            Assert.That(a1, Is.EqualTo(a));
            Assert.That(b1, Is.EqualTo(b));
            Assert.That(c1, Is.EqualTo(c));
        }

        [TestCase(5, 10, 25, false)]
        [TestCase(541, 588, 421, true)]
        [TestCase(827, 272, 126, false)]
        [TestCase(660, 514, 367, true)]
        [TestCase(39, 703, 839, false)]
        [TestCase(229, 871, 3, false)]
        public void IsTriangleValid(int a, int b, int c, bool expected)
        {
            bool valid = Day03.IsValidTriangle(a, b, c);
            Assert.That(valid, Is.EqualTo(expected));
        }

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day03.PartOne(PuzzleFile(DAY)), Is.EqualTo(993));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day03.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 6);
            yield return new TestCaseData(PuzzleFile(DAY), 1849);
        }
    }
}
