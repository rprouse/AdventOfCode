﻿using System.Collections;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day07Tests : TestBase
    {
        const int DAY = 07;

        [Test]
        public async Task TestPartOne()
        {
            Assert.That(await Day07.PartOne(PuzzleFile(DAY)), Is.EqualTo(277328));
        }

        [Test]
        [Ignore("Slower than I'd like :(")]
        public void TestPartTwo()
        {
            Assert.That(Day07.PartTwo(PuzzleFile(DAY)), Is.EqualTo(11304734));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public async Task TestPartOne(long[] program, long[] sequence, long expected)
        {
            Assert.That(await Day07.RunProgram(program, sequence), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(long[] program, long[] sequence, long expected)
        {
            Assert.That(Day07.RunProgramInFeedbackLoop(program, sequence), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(
                new long[] { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 },
                new long[] { 4, 3, 2, 1, 0 },
                43210);
            yield return new TestCaseData(
                new long[] { 3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0 },
                new long[] { 0, 1, 2, 3, 4 },
                54321);
            yield return new TestCaseData(
                new long[] { 3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0 },
                new long[] { 1, 0, 4, 3, 2 },
                65210);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(
                new long[] { 3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,
                            27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5 },
                new long[] { 9, 8, 7, 6, 5 },
                139629729);
            yield return new TestCaseData(
                new long[] { 3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,
                            -5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,
                            53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10 },
                new long[] { 9, 7, 8, 5, 6 },
                18216);
        }
    }
}
