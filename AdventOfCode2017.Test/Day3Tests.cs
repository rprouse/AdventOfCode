using NUnit.Framework;

namespace AdventOfCode2017.Test
{
    public class Day3Tests
    {
        [TestCase(1, 0)]
        [TestCase(12, 3)]
        [TestCase(23, 2)]
        [TestCase(1024, 31)]
        [TestCase(265149, 438)]
        public void TestCalculateDistance(int square, int expected)
        {
            Assert.That(Day3.CalculateDistance(square), Is.EqualTo(expected));
        }
    }
}
