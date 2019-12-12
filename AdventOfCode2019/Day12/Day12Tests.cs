using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day12Tests : TestBase
    {
        const int DAY = 12;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(Moon[] moons, int steps, int expected)
        {
            Assert.That(Day12.PartOne(moons, steps), Is.EqualTo(expected));
        }

        //[TestCaseSource(nameof(TestDataTwo))]
        //public void TestPartTwo()
        //{
        //    Assert.That(Day12.PartTwo(filename), Is.EqualTo(expected));
        //}

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(new Moon[] {
                new Moon(-1, 0, 2),
                new Moon(2, -10, -7),
                new Moon(4, -8, 8),
                new Moon(3, 5, -1)
            }, 10, 179);

            yield return new TestCaseData(new Moon[] {
                new Moon(-8, -10, 0),
                new Moon(5, 5, 10),
                new Moon(2, -7, 3),
                new Moon(9, -8, -3)
            }, 100, 1940);

            yield return new TestCaseData(new Moon[] {
                new Moon(-16, 15, -9),
                new Moon(-14, 5, 4),
                new Moon(2, 0, 6),
                new Moon(-3, 18, 9)
            }, 1000, 10664);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData();
        }
    }
}
