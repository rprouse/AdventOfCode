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
            Assert.That(Day05.PartTwo(PuzzleFile(DAY)), Is.EqualTo(652726));
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
            var result = Day05.RunIntcodeProgram(new int[] { 1101, 100, -1, 4, 0 }, 1);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void MultiplyNumber()
        {
            var result = Day05.RunIntcodeProgram(new int[] { 1002, 4, 3, 4, 33 }, 1);
            Assert.That(result, Is.EqualTo(0));
        }

        [TestCase(0, 0)]
        [TestCase(11, 1)]
        public void CanCompareNumbersUsingPositionMode(int input, int output)
        {
            var program = new int[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
            var result = Day05.RunIntcodeProgram(program, input);
            Assert.That(result, Is.EqualTo(output));
        }

        [TestCase(0, 0)]
        [TestCase(11, 1)]
        public void CanCompareNumbersUsingImmediateMode(int input, int output)
        {
            var program = new int[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };
            var result = Day05.RunIntcodeProgram(program, input);
            Assert.That(result, Is.EqualTo(output));
        }

        [TestCase(7, 999)]
        [TestCase(8, 1000)]
        [TestCase(9, 1001)]
        public void CanRunLargerProgram(int input, int output)
        {
            var program = new int[] {3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                                     1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                                     999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99};
            var result = Day05.RunIntcodeProgram(program, input);
            Assert.That(result, Is.EqualTo(output));
        }
    }
}
