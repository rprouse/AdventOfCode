using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day04Tests : TestBase
    {
        const int DAY = 04;

        [Test]
        public void GetDateTime()
        {
            var line = "[1518-11-03 00:05] Guard #10 begins shift";
            Assert.That(Day04.Shift.GetDateTime(line), Is.EqualTo(new DateTime(1518, 11, 03, 00, 05, 00)));
        }

        [Test]
        public void GetGuard()
        {
            var line = "[1518-11-03 00:05] Guard #10 begins shift";
            Assert.That(Day04.Shift.GetGuard(line), Is.EqualTo(10));
        }

        [TestCaseSource(nameof(ShiftData))]
        public void ParseShift(string[] lines, int i, int guard, int awake)
        {
            var shift = new Day04.Shift();
            shift.Parse(lines, i);
            Assert.That(shift.Guard, Is.EqualTo(guard));
            Assert.That(shift.MinutesAsleep, Is.EqualTo(awake));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day04.PartOne(filename), Is.EqualTo(expected));
        }


        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day04.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable ShiftData()
        {
            string[] lines = TestFile(DAY).ReadAllLines();
            yield return new TestCaseData(lines, 0, 10, 45);
            yield return new TestCaseData(lines, 5, 99, 10);
            yield return new TestCaseData(lines, 8, 10, 5);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 240);
            yield return new TestCaseData(PuzzleFile(DAY), 151754);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 4455);
            yield return new TestCaseData(PuzzleFile(DAY), 19896);
        }
    }
}
