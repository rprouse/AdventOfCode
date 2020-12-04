using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day04Tests : TestBase
    {
        const int DAY = 04;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Day04.PartOne(filename).Should().Be(expected);
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 2);
            yield return new TestCaseData(PuzzleFile(DAY), 260);
        }

        [Test]
        public void TestPartTwoInvalid()
        {
            Day04.PartTwo(PuzzleFile(DAY, "invalid.txt")).Should().Be(0);
        }

        [Test]
        public void TestPartTwoValid()
        {
            Day04.PartTwo(PuzzleFile(DAY, "valid.txt")).Should().Be(4);
        }

        [Test]
        public void TestPartTwo()
        {
            Day04.PartTwo(PuzzleFile(DAY)).Should().Be(153);
        }
    }
}
