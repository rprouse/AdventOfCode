using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day16Tests : TestBase
{
    const int DAY = 16;

    [Test]
    public void TestPartOne()
    {
        Day16.PartOne(PuzzleFile(DAY)).Should().Be(0);
    }

    [Test]
    public void TestPartTwo()
    {
        Day16.PartTwo(PuzzleFile(DAY)).Should().Be(0);
    }

    [TestCase("01", 0, Ignore = "If Needed")]
    public void TestCasePartOne(string text, int expected)
    {
        Day16.PartOne(text).Should().Be(expected);
    }

    [TestCase("", 0, Ignore = "If Needed")]
    public void TestCasePartTwo(string text, int expected)
    {
        Day16.PartTwo(text).Should().Be(expected);
    }

    [Test]
    public void CanParseLiteralPacket()
    {
        int offset = 0;
        Day16.Packet packet = Day16.Packet.ParsePacket("110100101111111000101000", ref offset);
        offset.Should().Be(21);
        packet.Version.Should().Be(6);
        packet.TypeId.Should().Be(4);
        packet.LiteralValue.Should().Be(2021);
    }

    [Test]
    public void CanParseOperatorPacketByLength()
    {
        int offset = 0;
        Day16.Packet packet = Day16.Packet.ParsePacket("00111000000000000110111101000101001010010001001000000000", ref offset);
        offset.Should().Be(49);
        packet.Version.Should().Be(1);
        packet.TypeId.Should().Be(6);
        packet.LengthTypeId.Should().Be(0);
        packet.LengthOrNumberOfSubPackets.Should().Be(27);
        packet.SubPackets.Should().HaveCount(2);
        packet.SubPackets[0].LiteralValue.Should().Be(10);
        packet.SubPackets[1].LiteralValue.Should().Be(20);
    }

    [Test]
    public void CanParseOperatorPacketByNumberOfSubPackets()
    {
        int offset = 0;
        Day16.Packet packet = Day16.Packet.ParsePacket("11101110000000001101010000001100100000100011000001100000", ref offset);
        offset.Should().Be(50);
        packet.Version.Should().Be(7);
        packet.TypeId.Should().Be(3);
        packet.LengthTypeId.Should().Be(1);
        packet.LengthOrNumberOfSubPackets.Should().Be(3);
        packet.SubPackets.Should().HaveCount(3);
        packet.SubPackets[0].LiteralValue.Should().Be(1);
        packet.SubPackets[1].LiteralValue.Should().Be(2);
        packet.SubPackets[2].LiteralValue.Should().Be(3);
    }

    [TestCaseSource(nameof(ParseHexData))]
    public void CanParseHex(string line, byte[] expected)
    {
        Day16.ParseHex(line).Should().BeEquivalentTo(expected);
    }

    [TestCaseSource(nameof(HexToBinaryStringData))]
    public void CanConvertHexToBinaryString(IEnumerable<byte> bytes, string expected)
    {
        Day16.HexToBinaryString(bytes).Should().Be(expected);
    }

    [TestCaseSource(nameof(BinaryStringToIntData))]
    public void CanConvertBinaryStringToInt(string binary, int expected)
    {
        Day16.BinaryStringToInt(binary).Should().Be(expected);
    }

    public static IEnumerable ParseHexData()
    {
        yield return new TestCaseData("F", new byte[] { 0xF0 });
        yield return new TestCaseData("01", new byte[] { 0x01 });
        yield return new TestCaseData("0123456789ABCDEF", new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF });
        yield return new TestCaseData("0123456789ABCDEF5", new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0x50 });
    }

    public static IEnumerable HexToBinaryStringData()
    {
        yield return new TestCaseData(new byte[] { 0xF0 }, "11110000");
        yield return new TestCaseData(new byte[] { 0x0F }, "00001111");
        yield return new TestCaseData(new byte[] { 0xEE, 0x0F }, "1110111000001111");
        yield return new TestCaseData(new byte[] { 0x22, 0x0F }, "0010001000001111");
    }

    public static IEnumerable BinaryStringToIntData()
    {
        yield return new TestCaseData("110", 6);
        yield return new TestCaseData("100", 4);
        yield return new TestCaseData("11110000", 0xF0);
        yield return new TestCaseData("00001111", 0x0F);
        yield return new TestCaseData("1110111000001111", 0xEE0F);
        yield return new TestCaseData("0010001000001111", 0x220F);
    }
}
