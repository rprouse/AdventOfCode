using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017.Day12
{
    public class Day12Tests : TestBase
    {
        public Day12Tests() : base(12) { }

        [Test]
        public void TestPartOne()
        {
            string str = File.ReadAllText(PuzzleFile);
            Assert.Pass(Day12.PartOne(str).ToString());
        }

        [Test]
        public void TestPartTwo()
        {
            string str = File.ReadAllText(PuzzleFile);
            Assert.Pass(Day12.PartTwo(str).ToString());
        }
    }
}
