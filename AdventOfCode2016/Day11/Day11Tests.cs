using System.Collections;
using System.IO;
using AdventOfCode.Core;
using AdventOfCode2016.DayEleven;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day11Tests : TestBase
    {
        const int DAY = 11;

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day11.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(Floors floors, int expected)
        {
            Assert.That(Day11.PartOne(floors), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day11.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            var test = new Floors();
            test.AddItem(0, new Item('H', false));
            test.AddItem(0, new Item('L', false));
            test.AddItem(1, new Item('H', true));
            test.AddItem(2, new Item('L', true));
            yield return new TestCaseData(test, 11).SetName("Day11Test");

            var puz = new Floors();
            puz.AddItem(0, new Item('P', true)); // Polonium
            puz.AddItem(1, new Item('P', false));

            puz.AddItem(0, new Item('T', true)); // Thulium
            puz.AddItem(0, new Item('T', false));

            puz.AddItem(0, new Item('M', true)); // Promethium
            puz.AddItem(1, new Item('M', false));

            puz.AddItem(0, new Item('R', true)); // Ruthium
            puz.AddItem(0, new Item('R', false));

            puz.AddItem(0, new Item('C', true)); // Cobalt
            puz.AddItem(0, new Item('C', false));

            yield return new TestCaseData(puz, 0).SetName("Day11Solution");
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
