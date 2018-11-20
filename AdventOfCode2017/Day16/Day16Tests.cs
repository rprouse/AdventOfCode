using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day16Tests : TestBase
    {
        const int DAY = 16;

        [Test]
        public void TestPartOne()
        {
            string str = File.ReadAllText(PuzzleFile(DAY));
            Assert.That(Day16.PartOne(str), Is.EqualTo("cgpfhdnambekjiol"));
        }

        [Test]
        public void TestPartTwo()
        {
            string str = File.ReadAllText(PuzzleFile(DAY));
            Assert.That(Day16.PartTwo(str), Is.EqualTo("gjmiofcnaehpdlbk"));
        }

        [Test]
        public void CanSpin()
        {
            char[] array = "abcde".ToCharArray();
            array.Spin(1);
            Assert.That(array, Is.EqualTo("eabcd".ToCharArray()));
        }

        [Test]
        public void CanExchange()
        {
            char[] array = "eabcd".ToCharArray();
            array.Exchange(3, 4);
            Assert.That(array, Is.EqualTo("eabdc".ToCharArray()));
        }

        [Test]
        public void CanPartner()
        {
            char[] array = "eabdc".ToCharArray();
            array.Partner('e', 'b');
            Assert.That(array, Is.EqualTo("baedc".ToCharArray()));
        }

        //[TestCaseSource(nameof(TestDataOne))]
        //public void TestPartOne(string filename, int expected)
        //{
        //    string str = File.ReadAllText(filename);
        //    Assert.That(Day16.PartOne(str), Is.EqualTo(expected));
        //}

        //[TestCaseSource(nameof(TestDataTwo))]
        //public void TestPartTwo(string filename, int expected)
        //{
        //    string str = File.ReadAllText(filename);
        //    Assert.That(Day16.PartTwo(str), Is.EqualTo(expected));
        //}

        //public static IEnumerable TestDataOne()
        //{
        //    yield return new TestCaseData(TestFile(DAY), 0);
        //    yield return new TestCaseData(PuzzleFile(DAY), 0);
        //}

        //public static IEnumerable TestDataTwo()
        //{
        //    yield return new TestCaseData(TestFile(DAY), 0);
        //    yield return new TestCaseData(PuzzleFile(DAY), 0);
        //}
    }
}
