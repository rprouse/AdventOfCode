using System.Collections;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2018
{
    public class Day12Tests : TestBase
    {
        const int DAY = 12;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, string initialState, int expected)
        {
            Assert.That(Day12.PartOne(filename, initialState), Is.EqualTo(expected));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day12.PartTwo(PuzzleFile(DAY), ".##..#.#..##..##..##...#####.#.....#..#..##.###.#.####......#.......#..###.#.#.##.#.#.###...##.###.#"), Is.EqualTo(3900000002467L));

        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), "#..#.#..##......###...###", 325);
            yield return new TestCaseData(PuzzleFile(DAY), ".##..#.#..##..##..##...#####.#.....#..#..##.###.#.####......#.......#..###.#.#.##.#.#.###...##.###.#", 3738);
        }
    }
}
