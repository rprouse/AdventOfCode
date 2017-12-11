using System;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day4Tests
    {
        [TestCase("aa bb cc dd ee", true)]
        [TestCase("aa bb cc dd aa", false)]
        [TestCase("aa bb cc dd aaa", true)]
        public void TestIsValid(string passphrase, bool expected)
        {
            Assert.That(passphrase.IsValid(), Is.EqualTo(expected));
        }

        [Test]
        public async Task TestNumberOfValidPassphrases()
        {
            int valid = await NumberOfValidPasswords(s => s.IsValid());
            Assert.That(valid, Is.EqualTo(466));
        }

        [TestCase("abcde fghij", true)]
        [TestCase("abcde xyz ecdab", false)]
        [TestCase("a ab abc abd abf abj", true)]
        [TestCase("iiii oiii ooii oooi oooo", true)]
        [TestCase("oiii ioii iioi iiio", false)]
        public void TestIsAnagramValid(string passphrase, bool expected)
        {
            Assert.That(passphrase.IsAnagramValid(), Is.EqualTo(expected));
        }

        [Test]
        public async Task TestNumberOfAnagramValidPassphrases()
        {
            int valid = await NumberOfValidPasswords(s => s.IsAnagramValid());
            Assert.That(valid, Is.EqualTo(251));
        }

        async Task<int> NumberOfValidPasswords(Func<string, bool> test)
        {
            int valid = 0;
            using (var reader = new StreamReader("Day04\\Day4-1.txt"))
            {
                string passphrase = await reader.ReadLineAsync();
                while (!string.IsNullOrWhiteSpace(passphrase))
                {
                    if (test.Invoke(passphrase)) valid++;
                    passphrase = await reader.ReadLineAsync();
                }
            }
            return valid;
        }
    }
}
