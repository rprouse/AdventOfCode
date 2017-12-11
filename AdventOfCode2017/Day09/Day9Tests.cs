using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day9Tests
    {
        [TestCase("Day09\\Day9.txt", 12803)]
        public void FindSolution(string filename, int expected)
        {
            var str = File.ReadLines(filename).First();
            Assert.That(str.ScoreGroups(), Is.EqualTo(expected));
        }

        [TestCase("Day09\\Day9.txt", 6425)]
        public void FindSolutionPartTwo(string filename, int expected)
        {
            var str = File.ReadLines(filename).First();
            Assert.That(str.CountGarbage(), Is.EqualTo(expected));
        }

        [TestCase("<>")]
        [TestCase("<random characters>")]
        [TestCase("<<<<>")]
        [TestCase("<{!>}>")]
        [TestCase("<!!>")]
        [TestCase("<!!!>>")]
        [TestCase("<{o\"i!a,<{i<a>")]
        public void CanStripGarbage(string line)
        {
            Assert.That(line.StripGarbage(), Is.EqualTo(""));
        }

        [TestCase("{}", 1)]
        [TestCase("{{{}}}", 6)]
        [TestCase("{{},{}}", 5)]
        [TestCase("{{{},{},{{}}}}", 16)]
        [TestCase("{<a>,<a>,<a>,<a>}", 1)]
        [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void CanScoreGroups(string line, int expected)
        {
            Assert.That(line.ScoreGroups(), Is.EqualTo(expected));
        }

        [TestCase("<>", 0)]
        [TestCase("<random characters>", 17)]
        [TestCase("<<<<>", 3)]
        [TestCase("<{!>}>", 2)]
        [TestCase("<!!>", 0)]
        [TestCase("<!!!>>", 0)]
        [TestCase("<{o\"i!a,<{i<a>", 10)]
        public void CanCountGarbage(string line, int expected)
        {
            Assert.That(line.CountGarbage(), Is.EqualTo(expected));
        }

    }
}
