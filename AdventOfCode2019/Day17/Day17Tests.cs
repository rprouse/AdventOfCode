using System.Collections;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day17Tests : TestBase
    {
        const int DAY = 17;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day17.PartOne(PuzzleFile(DAY)), Is.EqualTo(2804));
        }

        [Test]
        public void CalculatesAlignmentParameters()
        {
            var camera = new List<string>
            {
                "..#..........",
                "..#..........",
                "#######...###",
                "#.#...#...#.#",
                "#############",
                "..#...#...#..",
                "..#####...^..",
                ""
            };
            Assert.That(Day17.CalculateAlignmentParameters(camera), Is.EqualTo(76));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day17.PartTwo(PuzzleFile(DAY)), Is.EqualTo(833429));
        }
    }
}
