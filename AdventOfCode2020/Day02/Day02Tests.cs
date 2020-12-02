using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day02Tests : TestBase
    {
        const int DAY = 02;

        [TestCase("1-3 a: abcde", 1, 3, 'a', "abcde")]
        public void CanParsePasswordLine(string line, int min, int max, char c, string pass)
        {
            var password = new PasswordPolicy(line);
            password.Min.Should().Be(min);
            password.Max.Should().Be(max);
            password.Char.Should().Be(c);
            password.Password.Should().Be(pass);
        }

        [TestCase("1-3 a: abcde", true)]
        [TestCase("1-3 b: cdefg", false)]
        [TestCase("2-9 c: ccccccccc", true)]
        public void CanTestSledPasswordPolicy(string line, bool expected)
        {
            var password = new PasswordPolicy(line);
            password.IsSledPolicyValid().Should().Be(expected);
        }

        [TestCase("1-3 a: abcde", true)]
        [TestCase("1-3 b: cdefg", false)]
        [TestCase("2-9 c: ccccccccc", false)]
        public void CanTestTobogganPasswordPolicy(string line, bool expected)
        {
            var password = new PasswordPolicy(line);
            password.IsTobogganPolicyValid().Should().Be(expected);
        }

        [Test]
        public void TestPartOne()
        {
            Day02.PartOne(PuzzleFile(DAY)).Should().Be(643);
        }

        [Test]
        public void TestPartTwo()
        {
            Day02.PartTwo(PuzzleFile(DAY)).Should().Be(388);
        }
    }
}
