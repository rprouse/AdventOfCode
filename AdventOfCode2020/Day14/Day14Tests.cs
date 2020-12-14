using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day14Tests : TestBase
    {
        const int DAY = 14;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, long expected)
        {
            Day14.PartOne(filename).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, long expected)
        {
            Day14.PartTwo(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 165L);
            yield return new TestCaseData(PuzzleFile(DAY), 14553106347726L);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 208L);
            yield return new TestCaseData(PuzzleFile(DAY), 2737766154126L);
        }

        [TestCase("000000000000000000000000000000X1001X", 42, "000000000000000000000000000000X1101X")]
        [TestCase("00000000000000000000000000000000X0XX", 26, "00000000000000000000000000000001X0XX")]
        public void CanCalculateAddressMask(string mask, long ptr, string expected)
        {
            Day14.GetAddressMask(mask, ptr).Should().Be(expected);
        }

        [TestCaseSource(nameof(AddressesFromMask))]
        public void GetsAddressesFromMask(string mask, long[] expected)
        {
            var addresses = Day14.AddressesFromMask(mask);
            addresses.Should().HaveCount(expected.Length);
            addresses.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable AddressesFromMask()
        {
            yield return new TestCaseData("000000000000000000000000000000X1101X", new long[] { 26, 27, 58, 59 });
            yield return new TestCaseData("00000000000000000000000000000001X0XX", new long[] { 16, 17, 18, 19, 24, 25, 26, 27 });
        }
    }
}
