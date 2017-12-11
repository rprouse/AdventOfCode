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

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        [TestCase(6, 10)]
        [TestCase(7, 11)]
        [TestCase(8, 23)]
        [TestCase(9, 25)]
        [TestCase(10, 26)]
        [TestCase(11, 54)]
        [TestCase(12, 57)]
        [TestCase(13, 59)]
        [TestCase(14, 122)]
        [TestCase(15, 133)]
        [TestCase(16, 142)]
        [TestCase(17, 147)]
        [TestCase(18, 304)]
        [TestCase(19, 330)]
        [TestCase(20, 351)]
        [TestCase(21, 362)]
        [TestCase(22, 747)]
        [TestCase(23, 806)]
        [TestCase(265149, 4671229017281475194)]
        public void TestCalculateSums(int square, long expected)
        {
            Assert.That(Day3.CalculateSums(square), Is.EqualTo(expected));
        }

        [Test]
        public void TestNextLarger()
        {
            Assert.Pass(Day3.NextSum(265149).ToString());
        }
    }
}
