﻿using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day03Tests : TestBase
    {
        const int DAY = 03;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day03.PartOne(PuzzleFile(DAY)), Is.EqualTo(1195));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day03.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCase("R8,U5,L5,D3,", "U7,R6,D4,L4,", 6)]
        [TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void TestPartOne(string wire1, string wire2, int expected)
        {
            Assert.That(Day03.PartOne(wire1, wire2), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day03.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
