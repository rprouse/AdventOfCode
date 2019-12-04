using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day04Tests : TestBase
    {
        const int DAY = 04;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day04.PartOne(108457, 562041), Is.EqualTo(2779));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day04.PartTwo(108457, 562041), Is.EqualTo(1972));
        }

        [TestCase(111111, true)]
        [TestCase(223450, false)]
        [TestCase(123789, false)]
        [TestCase(122345, true)]
        [TestCase(111123, true)]
        [TestCase(135699, true)]
        public void CanFindValidPass(int pass, bool expected)
        {
            Assert.That(Day04.IsValidPassword(pass), Is.EqualTo(expected));
        }

        [TestCase(112233, true)]
        [TestCase(123444, false)]
        [TestCase(111122, true)]
        public void CanFindValidPass2(int pass, bool expected)
        {
            Assert.That(Day04.IsValidPassword2(pass), Is.EqualTo(expected));
        }

        [Test]
        public void CanFindDigit([Range(1, 6)] int d)
        {
            Assert.That(Day04.DigitAt(123456, d-1), Is.EqualTo(d));
        }
    }
}
