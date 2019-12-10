using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day10Tests : TestBase
    {
        const int DAY = 10;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day10.PartOne(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY, "Test01.txt"), 8);
            yield return new TestCaseData(TestFile(DAY, "Test02.txt"), 33);
            yield return new TestCaseData(TestFile(DAY, "Test03.txt"), 35);
            yield return new TestCaseData(TestFile(DAY, "Test04.txt"), 41);
            yield return new TestCaseData(TestFile(DAY, "Test05.txt"), 210);
            yield return new TestCaseData(PuzzleFile(DAY), 326);
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day10.PartTwo(PuzzleFile(DAY)), Is.EqualTo(1623));
        }

        [Test]
        public void TestPartTwoWithSmallMap()
        {
            Assert.That(Day10.PartTwo(TestFile(DAY, "Test06.txt")), Is.EqualTo(0));
        }

        [Test]
        public void TestPartTwoWithLargeMap()
        {
            Assert.That(Day10.PartTwo(TestFile(DAY, "Test05.txt")), Is.EqualTo(802));
        }

        [TestCaseSource(nameof(TestDirectionsData))]
        public void TestDirections(int x1, int y1, int x2, int y2, double dir)
        {
            Assert.That(Day10.AngleBetween(x1, y1, x2, y2), Is.EqualTo(dir));
        }

        public static IEnumerable TestDirectionsData()
        {
            yield return new TestCaseData(1, 1, 1, 0, 0d).SetName("TestDirections(000)");
            yield return new TestCaseData(1, 1, 2, 0, Math.PI / 4).SetName("TestDirections(045)");
            yield return new TestCaseData(1, 1, 2, 1, Math.PI / 2).SetName("TestDirections(090)");
            yield return new TestCaseData(1, 1, 2, 2, 3* Math.PI / 4).SetName("TestDirections(135)");
            yield return new TestCaseData(1, 1, 1, 2, Math.PI).SetName("TestDirections(180)");
            yield return new TestCaseData(1, 1, 0, 2, Math.PI * 1.25).SetName("TestDirections(225)");
            yield return new TestCaseData(1, 1, 0, 1, Math.PI * 1.5).SetName("TestDirections(270)");
            yield return new TestCaseData(1, 1, 0, 0, Math.PI * 1.75).SetName("TestDirections(315)");
        }
    }
}
