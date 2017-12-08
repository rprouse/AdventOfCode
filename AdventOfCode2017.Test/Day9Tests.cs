using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2017.Test
{
    public class Day9Tests
    {
        [TestCase("Day9.txt", 0)]
        [TestCase("Day9Test.txt", 0)]
        public void TestSomething(string filename, int expected)
        {
            var lines = Day9.ReadSomething(filename);
            Assert.That(lines.Count(), Is.EqualTo(expected));
        }
    }
}
