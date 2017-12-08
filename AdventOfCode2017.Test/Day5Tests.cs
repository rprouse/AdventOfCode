using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdventOfCode2017.Test
{
    public class Day5Tests
    {
        [Test]
        public void TestCountJumps()
        {
            var instructions = new int[] { 0, 3, 0, 1, -3 };
            Assert.That(instructions.CountJumps(), Is.EqualTo(5));
        }

        [Test]
        public async Task TestCountJumpsSolution()
        {
            var instructions = await ReadInstructions();
            Assert.That(instructions.CountJumps(), Is.EqualTo(358131));
        }

        [Test]
        public void TestCountJumpsPartTwo()
        {
            var instructions = new int[] { 0, 3, 0, 1, -3 };
            Assert.That(instructions.CountJumpsPartTwo(), Is.EqualTo(10));
        }

        [Test]
        public async Task TestCountJumpsSolutionPartTwo()
        {
            var instructions = await ReadInstructions();
            Assert.That(instructions.CountJumpsPartTwo(), Is.EqualTo(25558839));
        }


        async Task<int[]> ReadInstructions()
        {
            var instructions = new List<int>();
            using (var reader = new StreamReader("Day5-1.txt"))
            {
                string instruction = await reader.ReadLineAsync();
                while (!string.IsNullOrWhiteSpace(instruction))
                {
                    if (int.TryParse(instruction, out int i))
                        instructions.Add(i);
                    instruction = await reader.ReadLineAsync();
                }
            }
            return instructions.ToArray();
        }
    }
}
