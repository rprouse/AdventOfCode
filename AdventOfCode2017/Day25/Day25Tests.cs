using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day25Tests : TestBase
    {
        const int DAY = 25;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day25.PartOne(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 3);
            yield return new TestCaseData(PuzzleFile(DAY), 4769);
        }
    }
}
