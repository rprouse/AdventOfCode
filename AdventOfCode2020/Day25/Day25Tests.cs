using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;
using System.Numerics;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day25Tests : TestBase
    {
        const int DAY = 25;

        [TestCase(5764801L, 17807724L, 14897079L)]
        [TestCase(8458505L, 16050997L, 448851L)]
        public void TestPartOne(long cardKey, long doorKey, long expected)
        {
            Day25.PartOne(cardKey, doorKey).Should().Be(expected);
        }

        [TestCase(5764801L, 8)]
        [TestCase(17807724L, 11)]
        public void TestGetLoopSizeForKey(long key, int expected)
        {
            Day25.GetLoopSizeForKey(key).Should().Be(expected);
        }

        [TestCase(5764801L, 11, 14897079L)]
        [TestCase(17807724L, 8, 14897079L)]
        public void TestCalculateEncryptionKey(long key, int loopsize, long expected)
        {
            Day25.CalculateEncryptionKey(key, loopsize).Should().Be(expected);
        }

        [Test]
        public void TestPartTwo()
        {
            //Day25.PartTwo(PuzzleFile(DAY)).Should().Be(0);
        }
    }
}
