using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2015
{
    public class Day12Tests : TestBase
    {
        const int DAY = 12;

        [TestCase("[1,2,3]", 6)]
        [TestCase("{\"a\":2,\"b\":4}", 6)]
        [TestCase("[[[3]]]", 3)]
        [TestCase("{\"a\":{\"b\":4},\"c\":-1}", 3)]
        [TestCase("{\"a\":[-1,1]}", 0)]
        [TestCase("[-1,{ \"a\":1}]", 0)]
        [TestCase("[]", 0)]
        [TestCase("{ }", 0)]
        public void TestSumNumbers(string json, int expected)
        {
            Day12.SumNumbers(json).Should().Be(expected);
        }

        [Test]
        public void TestPartOne()
        {
            Day12.PartOne(PuzzleFile(DAY)).Should().Be(111754);
        }

        [TestCase("[1,2,3]", 6)]
        [TestCase("[1,{\"c\":\"red\",\"b\":2},3]", 4)]
        [TestCase("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}", 0)]
        [TestCase("[1,\"red\",5]", 6)]
        public void TestSumNumbersMinusRed(string json, int expected)
        {
            Day12.SumNumbersMinusRed(json).Should().Be(expected);
        }

        [Test]
        public void TestPartTwo()
        {
            Day12.PartTwo(PuzzleFile(DAY)).Should().Be(65402);
        }
    }
}
