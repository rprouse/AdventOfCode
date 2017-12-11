using NUnit.Framework;

namespace AdventOfCode2017.Day12
{
    public class Day12Tests
    {
        [Test]
        public void TestPartOne()
        {
            string[] steps = LineReader.SplitStrings ("Day12\\Data.txt");
            Assert.Pass(Day12.PartOne(steps).ToString());
        }

        [Test]
        public void TestPartTwo()
        {
            string[] steps = LineReader.SplitStrings("Day12\\Data.txt");
            Assert.Pass(Day12.PartTwo(steps).ToString());
        }
    }
}
