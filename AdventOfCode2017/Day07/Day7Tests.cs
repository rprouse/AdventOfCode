using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day7Tests
    {
        [Test]
        public void CanParseWithChildren()
        {
            var program = new Program("fwft (72) -> ktlj, cntj, xhth");
            Assert.That(program.Code, Is.EqualTo("fwft"));
            Assert.That(program.Weight, Is.EqualTo(72));
            Assert.That(program.ChildCodes, Has.Count.EqualTo(3));
        }

        [Test]
        public void CanParseWithoutChildren()
        {
            var program = new Program("ktlj (57)");
            Assert.That(program.Code, Is.EqualTo("ktlj"));
            Assert.That(program.Weight, Is.EqualTo(57));
            Assert.That(program.ChildCodes, Has.Count.EqualTo(0));
        }

        [TestCase("ktlj", true)]
        [TestCase("vvvv", false)]
        public void CanFindChild(string child, bool expected)
        {
            var program = new Program("fwft (72) -> ktlj, cntj, xhth");
            Assert.That(program.ContainsChild(child), Is.EqualTo(expected));
        }

        [TestCase("Day07\\Day7Test.txt", 13)]
        [TestCase("Day07\\Day7.txt", 1083)]
        public void CanReadPrograms(string filename, int expected)
        {
            var count = Day7.ReadPrograms(filename).Count();
            Assert.That(count, Is.EqualTo(expected));
        }

        [TestCase("Day07\\Day7Test.txt", "tknk")]
        [TestCase("Day07\\Day7.txt", "azqje")]
        public void CanFindRootProgram(string filename, string expected)
        {
            var programs = Day7.ReadPrograms(filename);
            var root = programs.FindRootProgram();
            Assert.That(root, Is.EqualTo(expected));
        }

        [TestCase("Day07\\Day7Test.txt", 60)]
        [TestCase("Day07\\Day7.txt", 646)]
        public void CanBalanceTower(string filename, int expected)
        {
            var programs = Day7.ReadPrograms(filename);
            var weight = programs.BalanceTower();
            Assert.That(weight, Is.EqualTo(expected));
        }
    }
}
