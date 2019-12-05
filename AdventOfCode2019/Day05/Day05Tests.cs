using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2019
{
    public class Day05Tests : TestBase
    {
        const int DAY = 05;

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day05.PartOne(PuzzleFile(DAY)), Is.EqualTo(15314507));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day05.PartTwo(PuzzleFile(DAY)), Is.EqualTo(0));
        }

        [TestCase(1002, 2)]
        [TestCase(11003, 3)]
        [TestCase(00099, 99)]
        public void CanGetOpCode(int ptr, int expected)
        {
            Assert.That(Day05.GetOpCode(ptr), Is.EqualTo(expected));
        }

        [TestCase(1002, 1, ParameterMode.Position)]
        [TestCase(1002, 2, ParameterMode.Immediate)]
        [TestCase(1002, 3, ParameterMode.Position)]
        [TestCase(11003, 1, ParameterMode.Position)]
        [TestCase(11003, 2, ParameterMode.Immediate)]
        [TestCase(11003, 3, ParameterMode.Immediate)]
        public void CanGetParametermode(int ptr, int param, ParameterMode expected)
        {
            Assert.That(Day05.GetParameterMode(ptr, param), Is.EqualTo(expected));
        }

        [Test]
        public void AddNegativeNumber()
        {
            var result = Day05.RunIntcodeProgram(new int[] { 1101, 100, -1, 4, 0 });
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void MultiplyNumber()
        {
            var result = Day05.RunIntcodeProgram(new int[] { 1002, 4, 3, 4, 33 });
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
