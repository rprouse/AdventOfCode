using System.Collections;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day11Tests : TestBase
    {
        const int DAY = 11;

        [Test]
        public async Task TestPartOne()
        {
            Assert.That(await Day11.PartOne(PuzzleFile(DAY)), Is.EqualTo(248));
        }
    }
}
