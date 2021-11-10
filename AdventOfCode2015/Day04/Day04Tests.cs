using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2015
{
    [Parallelizable(ParallelScope.Children)]
    public class Day04Tests : TestBase
    {
        [TestCase("abcdef609043", "000001DBBFA")]
        [TestCase("pqrstuv1048970", "000006136EF")]
        public void CheckMD5(string txt, string expected)
        {
            Day04.CreateMD5(txt).Should().StartWith(expected);
        }

        [TestCase("abcdef", 609043)]
        [TestCase("pqrstuv", 1048970)]
        [TestCase("yzbqklnj", 282749)]
        public void TestPartOne(string secret, int expected)
        {
            Day04.PartOne(secret).Should().Be(expected);
        }

        [Test]
        public void TestPartTwo()
        {
            // Takes 13 seconds
            // Day04.PartTwo("yzbqklnj").Should().Be(9962624);
        }
    }
}
