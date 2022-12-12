using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Core.Tests;

public class AocMathTests
{
    [TestCase(7u, 5u, 35ul)]
    [TestCase(36u, 24u, 72ul)]
    public void TestLeastCommonMultiple(uint a, uint b, ulong expected)
    {
        AocMath.LeastCommonMultiple(a, b).Should().Be(expected);
    }

    [TestCase(7u, 5u, 1u)]
    [TestCase(36u, 24u, 12u)]
    [TestCase(36u, 12u, 6u)]
    public void TestGreatestCommonFactor(uint a, uint b, uint expected)
    {
        AocMath.GreatestCommonFactor(a, b).Should().Be(expected);
    }

    [Test]
    public void CanCalculateLeastCommonMultipe()
    {
        AocMath.LeastCommonMultiple(new uint[] { 23, 19, 13, 17 }).Should().Be(96577);
    }
}
