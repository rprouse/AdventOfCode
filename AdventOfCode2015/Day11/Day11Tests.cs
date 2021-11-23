using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2015
{
    public class Day11Tests : TestBase
    {
        const int DAY = 11;

        [TestCase("abcdefgh", "abcdffaa")]
        [TestCase("ghijklmn", "ghjaabcc")]
        [TestCase("hepxcrrq", "hepxxyzz")]
        public void TestPartOne(string pass, string next)
        {
            Day11.PartOne(pass).Should().Be(next);
        }

        [TestCase("aaaaaa", "aaaaab")]
        [TestCase("aaaaaz", "aaaaba")]
        [TestCase("aaaaza", "aaaazb")]
        [TestCase("aaaazz", "aaabaa")]
        [TestCase("yzzzzz", "zaaaaa")]
        public void TestIncrementPassword(string pass, string expected)
        {
            Day11.IncrementPassword(pass).Should().Be(expected);
        }

        [TestCase("hijklmmn", false)]
        [TestCase("abbceffg", false)]
        [TestCase("abbcegjk", false)]
        [TestCase("abcdffaa", true)]
        [TestCase("ghjaabcc", true)]
        public void TestIsValid(string pass, bool valid)
        {
            Day11.IsValid(pass).Should().Be(valid);
        }

        [Test]
        public void TestPartTwo()
        {
            Day11.PartTwo("hepxcrrq").Should().Be("heqaabcc");
        }
    }
}
