using System.Collections;
using System.Linq;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day15Tests : TestBase
    {
        const int DAY = 15;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int expected)
        {
            Assert.That(Day15.PartOne(filename), Is.EqualTo(expected));
        }

        [Test]
        public void CanFindGoals()
        {
            var board = new Day15.Board(TestFile(DAY, "Test1.txt"));
            var goals = board.Goals(2, 1).ToArray();
            Assert.That(goals, Has.Length.EqualTo(3));
            Assert.That(goals[0].x, Is.EqualTo(4));
            Assert.That(goals[0].y, Is.EqualTo(1));
            Assert.That(goals[1].x, Is.EqualTo(3));
            Assert.That(goals[1].y, Is.EqualTo(2));
            Assert.That(goals[2].x, Is.EqualTo(5));
            Assert.That(goals[2].y, Is.EqualTo(5));
        }

        [TestCase(2, 1, Day15.Board.ELF)]
        [TestCase(4, 2, Day15.Board.GOBLIN)]
        public void DeterminesEnemy(int x, int y, char expected)
        {
            var board = new Day15.Board(TestFile(DAY, "Test1.txt"));
            Assert.That(board.DetermineEnemy(x, y), Is.EqualTo(expected));
        }

        [TestCase(2, 1, false)]
        [TestCase(4, 2, true)]
        [TestCase(5, 2, true)]
        [TestCase(5, 3, true)]
        [TestCase(5, 4, true)]
        [TestCase(3, 4, false)]
        public void CanAttack(int x, int y, bool expected)
        {
            var board = new Day15.Board(TestFile(DAY, "Test1.txt"));
            Assert.That(board.CanAttack(x, y), Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day15.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 27730);
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 36334);
            yield return new TestCaseData(TestFile(DAY, "Test3.txt"), 39514);
            yield return new TestCaseData(TestFile(DAY, "Test4.txt"), 27755);
            yield return new TestCaseData(TestFile(DAY, "Test5.txt"), 28944);
            yield return new TestCaseData(TestFile(DAY, "Test6.txt"), 18740);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }

        public static IEnumerable TestDataTwo()
        {
            yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
