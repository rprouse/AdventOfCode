using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day01Tests : TestBase
    {
        const int DAY = 01;

        [TestCase(12, 2)]
        [TestCase(14, 2)]
        [TestCase(1969, 654)]
        [TestCase(100756, 33583)]
        public void CanCalculateFuelRequired(int mass, int expected)
        {
            var actual = Day01.FuelRequired(mass);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(14, 2)]
        [TestCase(1969, 966)]
        [TestCase(100756, 50346)]
        public void CanCalculateFuelRequiredWithFuelForTheFuel(int mass, int expected)
        {
            var actual = Day01.FuelRequiredWithFuel(mass);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day01.PartOne(PuzzleFile(DAY)), Is.EqualTo(3154112));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day01.PartTwo(PuzzleFile(DAY)), Is.EqualTo(4728317));
        }
    }
}
