using AdventOfCode2017;
using NUnit.Framework;

namespace Tests
{
    public class Day1Tests
    {
        [TestCase("1122", 3)]
        [TestCase("1111", 4)]
        [TestCase("1234", 0)]
        [TestCase("91212129", 9)]
        public void TestCaptcha(string captcha, int expected)
        {
            var sum = Day1.CalculateCaptcha(captcha);
            Assert.That(sum, Is.EqualTo(expected));
            TestContext.WriteLine(sum);
        }
    }
}