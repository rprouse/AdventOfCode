using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day07Tests : TestBase
    {
        const int DAY = 07;

        [TestCase("abba[mnop]qrst", true)]
        [TestCase("abcd[bddb]xyyx", false)]
        [TestCase("aaaa[qwer]tyui", false)]
        [TestCase("ioxxoj[asdfgh]zxcvbn", true)]
        public void TestTLSSupport(string ipv7, bool supportsTls)
        {
            Assert.That(Day07.SupportsTLS(ipv7), Is.EqualTo(supportsTls));
        }

        [TestCase("aba[bab]xyz", true)]
        [TestCase("xyx[xyx]xyx", false)]
        [TestCase("aaa[kek]eke", true)]
        [TestCase("zazbz[bzb]cdb", true)]
        public void TestSSLSupport(string ipv7, bool supportsSsl)
        {
            Assert.That(Day07.SupportsSSL(ipv7), Is.EqualTo(supportsSsl));
        }

        [TestCase(0, true)]
        [TestCase(1, false)]
        public void TestTLSSupportAtIndex(int index, bool supportsTls)
        {
            Assert.That(Day07.SupportsTLS("abbaqrst", index), Is.EqualTo(supportsTls));
        }

        [TestCaseSource(nameof(TestOutsideBrackets))]
        public void CanStripHypernetSequences(string ipv7, string[] stripped)
        {
            Assert.That(Day07.StripHypernetSequences(ipv7), Is.EqualTo(stripped));
        }

        [TestCaseSource(nameof(TestInsideBrackets))]
        public void CanGetHypernetSequences(string ipv7, string[] sequences)
        {
            Assert.That(Day07.GetHypernetSequences(ipv7), Is.EqualTo(sequences));
        }

        [Test]
        public void CanConvertAbaToBab()
        {
            Assert.That(Day07.ConvertAbaToBab("ded"), Is.EqualTo("ede"));
        }

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day07.PartOne(PuzzleFile(DAY)), Is.EqualTo(105));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day07.PartTwo(PuzzleFile(DAY)), Is.EqualTo(258));
        }

        public static IEnumerable TestOutsideBrackets()
        {
            yield return new TestCaseData("abbaqrst", new [] { "abbaqrst" });
            yield return new TestCaseData("abba[mnop]qrst", new[] { "abba", "qrst" });
            yield return new TestCaseData("abcd[bddb]xyyx", new[] { "abcd", "xyyx" });
            yield return new TestCaseData("aaaa[qwer]tyui", new[] { "aaaa", "tyui" });
            yield return new TestCaseData("ioxxoj[asdfgh]zxcvbn", new[] { "ioxxoj", "zxcvbn" });
            yield return new TestCaseData("ioxxoj[asdfgh]zxcvbn[sdfas]sldfjk", new[] { "ioxxoj", "zxcvbn", "sldfjk" });
        }

        public static IEnumerable TestInsideBrackets()
        {
            yield return new TestCaseData("abbaqrst", new string[] { });
            yield return new TestCaseData("abba[mnop]qrst", new[] { "mnop" });
            yield return new TestCaseData("abcd[bddb]xyyx", new[] { "bddb" });
            yield return new TestCaseData("aaaa[qwer]tyui", new[] { "qwer" });
            yield return new TestCaseData("ioxxoj[asdfgh]zxcvbn", new[] { "asdfgh" });
            yield return new TestCaseData("ioxxoj[asdfgh]zxcvbn[sdfas]sldfjk", new[] { "asdfgh", "sdfas" });
        }
    }
}
