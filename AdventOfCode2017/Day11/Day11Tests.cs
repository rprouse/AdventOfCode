using NUnit.Framework;

namespace AdventOfCode2017.Day11
{
    public class Day11Tests
    {
        [Test]
        public void TestPartOne()
        {
            string line = LineReader.ReadLine("Day11\\Data.txt");
            Assert.Pass(Day11.PartOne(line).ToString());
        }

        [Test]
        public void TestPartTwo()
        {
            string line = LineReader.ReadLine("Day11\\Data.txt");
            Assert.Pass(Day11.PartTwo(line).ToString());
        }
    }
}
