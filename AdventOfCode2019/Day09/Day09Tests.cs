using System.Collections;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day09Tests : TestBase
    {
        const int DAY = 09;

        [Test]
        public async Task TestPartOne()
        {
            Assert.That(await Day09.PartOne(PuzzleFile(DAY)), Is.EqualTo(2789104029));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day09.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public async Task TestPartOne(long[] program, long[] input, long expected)
        {
            Assert.That(await Day09.RunProgram(program, input), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day09.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(
                new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 },
                new long[] { },
                99);
            yield return new TestCaseData(
                new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 },
                new long[] { },
                1219070632396864);
            yield return new TestCaseData(
                new long[] { 104, 1125899906842624, 99 },
                new long[] { },
                1125899906842624);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
