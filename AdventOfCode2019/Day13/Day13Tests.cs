using System.Collections;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day13Tests : TestBase
    {
        const int DAY = 13;

        [Test]
        public async Task TestPartOne()
        {
            Assert.That(await Day13.PartOne(PuzzleFile(DAY)), Is.EqualTo(398));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day13.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day13.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
