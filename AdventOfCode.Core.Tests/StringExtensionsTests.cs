using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Core.Tests
{
    public class StringExtensionsTests
    {
        [TestCase("abcde", "abc", true)]
        [TestCase("abcde", "ace", true)]
        [TestCase("abcde", "abcde", true)]
        [TestCase("abcde", "abcf", false)]
        [TestCase("abcde", "", true)]
        [TestCase("abcde", "fghi", false)]
        public void TestIsSupersetOf(string superset, string subset, bool expected)
        {
            superset.IsSupersetOf(subset).Should().Be(expected);
        }

        [TestCase("abcde", "abc", true)]
        [TestCase("abcde", "ace", true)]
        [TestCase("abcde", "abcde", true)]
        [TestCase("abcde", "abcf", false)]
        [TestCase("abcde", "", true)]
        [TestCase("abcde", "fghi", false)]
        public void TestIsSubsetOf(string superset, string subset, bool expected)
        {
            subset.IsSubsetOf(superset).Should().Be(expected);
        }
    }
}