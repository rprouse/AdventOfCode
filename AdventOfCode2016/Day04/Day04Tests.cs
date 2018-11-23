using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;

namespace AdventOfCode2016
{
    public class Day04Tests : TestBase
    {
        const int DAY = 04;

        [TestCase("aaaaa-bbb-z-y-x-123[abxyz]", "aaaaa-bbb-z-y-x", 123, "abxyz")]
        [TestCase("a-b-c-d-e-f-g-h-987[abcde]", "a-b-c-d-e-f-g-h", 987, "abcde")]
        [TestCase("not-a-real-room-404[oarel]", "not-a-real-room", 404, "oarel")]
        [TestCase("totally-real-room-200[decoy]", "totally-real-room", 200, "decoy")]
        public void CanParseRooms(string code, string name, int sector, string checksum)
        {
            var day = new Day04(code);
            Assert.That(day.Encrypted, Is.EqualTo(name));
            Assert.That(day.Sector, Is.EqualTo(sector));
            Assert.That(day.Checksum, Is.EqualTo(checksum));
        }

        [TestCase("aaaaa-bbb-z-y-x-123[abxyz]", true)]
        [TestCase("a-b-c-d-e-f-g-h-987[abcde]", true)]
        [TestCase("not-a-real-room-404[oarel]", true)]
        [TestCase("totally-real-room-200[decoy]", false)]
        public void CanFindRealRooms(string code, bool real)
        {
            var day = new Day04(code);
            Assert.That(day.RealRoom, Is.EqualTo(real));
        }

        [TestCase("aaaaa-bbb-z-y-x", "abxyz")]
        [TestCase("a-b-c-d-e-f-g-h", "abcde")]
        [TestCase("not-a-real-room", "oarel")]
        public void CanCalculateChecksum(string name, string checksum)
        {
            Assert.That(Day04.CalculateChecksum(name), Is.EqualTo(checksum));
        }

        [Test]
        public void CanDecryptName()
        {
            Assert.That(Day04.Decrypt("qzmt-zixmtkozy-ivhz", 343), Is.EqualTo("very encrypted name"));
        }

        [Test]
        public void TestPartOne()
        {
            Assert.That(Day04.PartOne(PuzzleFile(DAY)), Is.EqualTo(158835));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day04.PartTwo(PuzzleFile(DAY)), Is.EqualTo(993));
        }
    }
}
