using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day16Tests : TestBase
    {
        const int DAY = 16;

        [TestCase("Before: [3, 2, 1, 1]", 3, 2, 1, 1)]
        [TestCase("After:  [3, 2, 2, 1]", 3, 2, 2, 1)]
        public void CanParseRegisterState(string line, int ae, int be, int ce, int de)
        {
            (int a, int b, int c, int d) = Day16.ParseRegisterState(line);
            Assert.That(a, Is.EqualTo(ae));
            Assert.That(b, Is.EqualTo(be));
            Assert.That(c, Is.EqualTo(ce));
            Assert.That(d, Is.EqualTo(de));
        }

        [Test]
        public void CanParseOperation()
        {
            (int o, int a, int b, int c) = Day16.ParseOperation("9 2 1 2");
            Assert.That(o, Is.EqualTo(9));
            Assert.That(a, Is.EqualTo(2));
            Assert.That(b, Is.EqualTo(1));
            Assert.That(c, Is.EqualTo(2));
        }

        [Test]
        public void TestPartOneTest()
        {
            Assert.That(Day16.PartOne(TestFile(DAY)), Is.EqualTo(1));
        }

        [Test]
        public void TestPartOneSolution()
        {
            Assert.That(Day16.PartOne(PuzzleFile(DAY, "Data1.txt")), Is.EqualTo(580));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day16.PartTwo(PuzzleFile(DAY, "Data2.txt")), Is.EqualTo(537));
        }
    }
}
