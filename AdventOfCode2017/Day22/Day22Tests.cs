using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day22Tests : TestBase
    {
        const int DAY = 22;

        [TestCase(Day22.Direction.Up, true, Day22.Direction.Right)]
        [TestCase(Day22.Direction.Up, false, Day22.Direction.Left)]
        [TestCase(Day22.Direction.Right, true, Day22.Direction.Down)]
        [TestCase(Day22.Direction.Right, false, Day22.Direction.Up)]
        [TestCase(Day22.Direction.Down, true, Day22.Direction.Left)]
        [TestCase(Day22.Direction.Down, false, Day22.Direction.Right)]
        [TestCase(Day22.Direction.Left, true, Day22.Direction.Up)]
        [TestCase(Day22.Direction.Left, false, Day22.Direction.Down)]
        public void CanTurn(Day22.Direction start, bool infected, Day22.Direction expected)
        {
            var virus = new Day22.Virus(new string[] { "...", "...", "..." });
            if (infected) virus.Infect();
            virus._dir = start;
            virus.Turn();
            Assert.That(virus._dir, Is.EqualTo(expected));
        }

        [Test]
        public void CanReadBoard()
        {
            var virus = new Day22.Virus(new string[] { "###", ".#.", "..." });
            Assert.That(virus._nodes["-1,1"], Is.EqualTo('i'));
            Assert.That(virus._nodes["0,1"], Is.EqualTo('i'));
            Assert.That(virus._nodes["1,1"], Is.EqualTo('i'));
            Assert.That(virus._nodes["-1,0"], Is.EqualTo('c'));
            Assert.That(virus._nodes["0,0"], Is.EqualTo('i'));
            Assert.That(virus._nodes["1,0"], Is.EqualTo('c'));
            Assert.That(virus._nodes["-1,-1"], Is.EqualTo('c'));
            Assert.That(virus._nodes["0,-1"], Is.EqualTo('c'));
            Assert.That(virus._nodes["1,-1"], Is.EqualTo('c'));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day22.PartOne(filename), Is.EqualTo(expected));
        }

        [Ignore("Works, but slow")]
        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day22.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 5587);
            yield return new TestCaseData(PuzzleFile(DAY), 5223);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 2511944);
            yield return new TestCaseData(PuzzleFile(DAY), 2511456);
        }
    }
}
