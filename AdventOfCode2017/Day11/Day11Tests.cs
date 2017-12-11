using NUnit.Framework;

namespace AdventOfCode2017.Day11
{
    public class Day11Tests
    {
        [Test] // 794
        public void TestPartOne()
        {
            string line = LineReader.ReadLine("Day11\\Data.txt");
            string[] steps = line.Split(',');
            Assert.Pass(Day11.PartOne(steps).ToString());
        }

        [Test]
        public void TestPartTwo()
        {
            string line = LineReader.ReadLine("Day11\\Data.txt");
            string[] steps = line.Split(',');
            Assert.Pass(Day11.PartTwo(steps).ToString());
        }

        [TestCase("ne,ne,ne", 3)]
        [TestCase("ne,ne,sw,sw", 0)]
        [TestCase("ne,ne,s,s", 2)]
        [TestCase("se,sw,se,sw,sw", 3)]
        public void CanCountSteps(string line, int expected)
        {
            string[] steps = line.Split(',');
            Assert.That(Day11.PartOne(steps), Is.EqualTo(expected));
        }
    }
}
