using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day08Tests
    {
        [TestCase("b inc 5 if a > 1", "b", 5, "a", ">", 1)]
        [TestCase("a inc 1 if b < 5", "a", 1, "b", "<", 5)]
        [TestCase("c dec -10 if a >= 1", "c", 10, "a", ">=", 1)]
        [TestCase("c inc -20 if c == 10", "c", -20, "c", "==", 10)]
        public void CanParseInstructions(string line, string reg, int inc, string tgt, string op, int val)
        {
            var instr = new Instruction(line);
            Assert.That(instr.Register, Is.EqualTo(reg));
            Assert.That(instr.Increment, Is.EqualTo(inc));
            Assert.That(instr.TargetRegister, Is.EqualTo(tgt));
            Assert.That(instr.Opererator, Is.EqualTo(op));
            Assert.That(instr.ConditionalValue, Is.EqualTo(val));
        }

        [TestCase("Day08\\Day8Test.txt", 4)]
        [TestCase("Day08\\Day8.txt", 1000)]
        public void CanReadInstructions(string filename, int expected)
        {
            var count = Day8.ReadInstructions(filename).Count();
            Assert.That(count, Is.EqualTo(expected));
        }

        [TestCase("Day08\\Day8Test.txt", 1)]
        [TestCase("Day08\\Day8.txt", 4902)]
        public void CanRunProgram(string filename, int expected)
        {
            var registers = Day8.ReadInstructions(filename).RunProgram(out int max);
            Assert.That(registers.FindLargestRegister(), Is.EqualTo(expected));
        }

        [TestCase("Day08\\Day8Test.txt", 10)]
        [TestCase("Day08\\Day8.txt", 7037)]
        public void CanFindHighestValue(string filename, int expected)
        {
            var registers = Day8.ReadInstructions(filename).RunProgram(out int max);
            Assert.That(max, Is.EqualTo(expected));
        }
    }
}
