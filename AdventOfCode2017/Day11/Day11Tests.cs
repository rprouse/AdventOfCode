using NUnit.Framework;

namespace AdventOfCode2017.Day11
{
    public class Day11Tests : TestBase
    {
        public Day11Tests() : base(11) { }

        [Test] // 794
        public void TestPartOne()
        {
            string[] steps = FileExtensions.SplitStrings(PuzzleFile);
            Assert.Pass(Day11.PartOne(steps).ToString());
        }

        [Test] // 1524
        public void TestPartTwo()
        {
            string[] steps = FileExtensions.SplitStrings(PuzzleFile);
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
