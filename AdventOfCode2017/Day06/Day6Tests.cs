using System.Collections;
using NUnit.Framework;

namespace AdventOfCode2017.Test
{
    public class Day6Tests
    {
        [TestCaseSource(nameof(TestData))]
        public void TestReallocation(int[] blocks, int expected)
        {
            Assert.That(blocks.CountReallocations(), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestLoopSize(int[] blocks, int expected)
        {
            Assert.That(blocks.FindLoopSize(), Is.EqualTo(expected));
        }

        public static IEnumerable TestData()
        {
            yield return new TestCaseData(
                new int[] { 0, 2, 7, 0 },
                5);

            yield return new TestCaseData(
                new int[] { 10, 3, 15, 10, 5, 15, 5, 15, 9, 2, 5, 8, 5, 2, 3, 6 },
                14029);

        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(
                new int[] { 0, 2, 7, 0 },
                4);

            yield return new TestCaseData(
                new int[] { 10, 3, 15, 10, 5, 15, 5, 15, 9, 2, 5, 8, 5, 2, 3, 6 },
                2765);

        }
    }
}
