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
        public void TestPartOne()
        {
            Assert.That(Day13.PartOne(PuzzleFile(DAY)), Is.EqualTo(398));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day13.PartTwo(PuzzleFile(DAY)), Is.EqualTo(19447));
        }
    }
}
