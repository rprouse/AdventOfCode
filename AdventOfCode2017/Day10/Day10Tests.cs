using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace AdventOfCode2017.Test
{
    public class Day10Tests
    {
        [TestCaseSource(nameof(SolutionData))]
        public void CanMultiplyFirstTwo(IEnumerable<int> twists, int length, int expected)
        {
            int result = Day10.TwistMultiplier(length, twists);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CanDoTheTwist()
        {
            int[] array = Day10.Twist(5, new [] { 3, 4, 1, 5 });
            Assert.That(array, Is.EqualTo(new[] { 3, 4, 2, 1, 0 }));
        }

        [TestCaseSource(nameof(ReverseSectionData))]
        public void CanReverseSection(int[] array, int start, int length, int[] expected)
        {
            array.ReverseSection(start, length);
            Assert.That(array, Is.EqualTo(expected));
        }

        public static IEnumerable ReverseSectionData()
        {
            yield return new TestCaseData(new[] { 0, 1, 2, 3, 4 }, 0, 3, new[] { 2, 1, 0, 3, 4 });
            yield return new TestCaseData(new[] { 2, 1, 0, 3, 4 }, 3, 4, new[] { 4, 3, 0, 1, 2 });
            yield return new TestCaseData(new[] { 4, 3, 0, 1, 2 }, 3, 1, new[] { 4, 3, 0, 1, 2 });
            yield return new TestCaseData(new[] { 4, 3, 0, 1, 2 }, 1, 5, new[] { 3, 4, 2, 1, 0 });
        }

        public static IEnumerable SolutionData()
        {
            yield return new TestCaseData(new[] { 3, 4, 1, 5 }, 5, 12);
            yield return new TestCaseData(new[] { 76, 1, 88, 148, 166, 217, 130, 0, 128, 254, 16, 2, 130, 71, 255, 229 }, 256, 29240);
        }

        // 4db3799145278dc9f73dcdbc680bd53d
        [Test]
        public void PartTwo()
        {
            Assert.Pass(Day10.PartTwo("76,1,88,148,166,217,130,0,128,254,16,2,130,71,255,229"));
        }
    }
}
