using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day22Tests : TestBase
    {
        const int DAY = 22;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day22.PartOne(PuzzleFile(DAY)), Is.EqualTo(6289));
        }

        [Test]
        public void CanDealIntoNewStack()
        {
            //var cards = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var expected = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            var cards = new SpaceCards(10);
            cards.DealIntoNewStack();
            Assert.That(cards.Cards, Is.EqualTo(expected));
        }

        [Test]
        public void CanCutCards()
        {
            var expected = new int[] { 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 };
            var cards = new SpaceCards(10);
            cards.CutCards(3);
            Assert.That(cards.Cards, Is.EqualTo(expected));
        }

        [Test]
        public void CanCutCardsWithNegative()
        {
            var expected = new int[] { 6, 7, 8, 9, 0, 1, 2, 3, 4, 5 };
            var cards = new SpaceCards(10);
            cards.CutCards(-4);
            Assert.That(cards.Cards, Is.EqualTo(expected));
        }

        [Test]
        public void CanDealWithIncrement()
        {
            var expected = new int[] { 0, 7, 4, 1, 8, 5, 2, 9, 6, 3 };
            var cards = new SpaceCards(10);
            cards.DealWithIncrement(3);
            Assert.That(cards.Cards, Is.EqualTo(expected));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day22.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCaseSource(nameof(TestDataOne))]
        public void CanShuffleCards(string filename, int[] expected)
        {
            var cards = new SpaceCards(10);
            cards.Shuffle(filename);
            Assert.That(cards.Cards, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(TestDataTwo))]
        public void TestPartTwo(string filename, int expected)
        {
            Assert.That(Day22.PartTwo(filename), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY, "Test1.txt"), new int[] { 0, 3, 6, 9, 2, 5, 8, 1, 4, 7 });
            yield return new TestCaseData(TestFile(DAY, "Test2.txt"), new int[] { 3, 0, 7, 4, 1, 8, 5, 2, 9, 6 });
            yield return new TestCaseData(TestFile(DAY, "Test3.txt"), new int[] { 6, 3, 0, 7, 4, 1, 8, 5, 2, 9 });
            yield return new TestCaseData(TestFile(DAY, "Test4.txt"), new int[] { 9, 2, 5, 8, 1, 4, 7, 0, 3, 6 });
        }

        public static IEnumerable TestDataTwo()
        {
            //yield return new TestCaseData(TestFile(DAY), 0);
            yield return new TestCaseData(PuzzleFile(DAY), 0);
        }
    }
}
