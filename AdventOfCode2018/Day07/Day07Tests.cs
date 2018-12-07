using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day07Tests : TestBase
    {
        const int DAY = 07;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, string expected)
        {
            Assert.That(Day07.PartOne(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), "CABDFE");
            yield return new TestCaseData(PuzzleFile(DAY), "OUGLTKDJVBRMIXSACWYPEQNHZF");
        }
    }
}
