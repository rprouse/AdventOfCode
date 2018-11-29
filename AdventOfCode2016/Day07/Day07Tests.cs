using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day07Tests : TestBase
    {
        const int DAY = 07;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int width, int height, int expected)
        {
            Assert.That(Day07.PartOne(filename, width, height), Is.EqualTo(expected));
        }

        [Test]
        public void TestPartTwo()
        {
            string expected = @"####..##...##..###...##..###..#..#.#...#.##...##..
#....#..#.#..#.#..#.#..#.#..#.#..#.#...##..#.#..#.
###..#..#.#..#.#..#.#....#..#.####..#.#.#..#.#..#.
#....#..#.####.###..#.##.###..#..#...#..####.#..#.
#....#..#.#..#.#.#..#..#.#....#..#...#..#..#.#..#.
####..##..#..#.#..#..###.#....#..#...#..#..#..##..
";

            Assert.That(Day07.PartTwo(PuzzleFile(DAY), 50, 6), Is.EqualTo(expected));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 7, 3, 6);
            yield return new TestCaseData(PuzzleFile(DAY), 50, 6, 128);
        }
    }
}
