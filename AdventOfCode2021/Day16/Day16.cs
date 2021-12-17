using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day16
{
    public static int PartOne(string filename)
    {
        string line = filename.ReadAll();
        var bytes = ParseHex(line);
        var binary = HexToBinaryString(bytes);
        int offset = 0;
        Day16.Packet packet = Day16.Packet.ParsePacket(binary, ref offset);
        return packet.CalculateVersionSum();
    }

    public static long PartTwo(string filename)
    {
        string line = filename.ReadAll();
        var bytes = ParseHex(line);
        var binary = HexToBinaryString(bytes);
        int offset = 0;
        Day16.Packet packet = Day16.Packet.ParsePacket(binary, ref offset);
        return packet.CalculateValue();
    }

    internal class Packet
    {
        public int Version { get; private set; }
        public int TypeId { get; private set; }
        public long LiteralValue { get; private set; }
        public int LengthTypeId { get; private set; }
        public int LengthOrNumberOfSubPackets { get; private set; }
        public List<Packet> SubPackets { get; } = new List<Packet>();

        public int CalculateVersionSum() =>
            Version + SubPackets.Sum(p => p.CalculateVersionSum());

        public long CalculateValue() =>
            TypeId switch
            {
                0 => Sum(),
                1 => Product(),
                2 => Minimum(),
                3 => Maximum(),
                4 => LiteralValue,
                5 => GreaterThan(),
                6 => LessThan(),
                7 => EqualTo(),
                _ => throw new NotImplementedException()
            };

        private long Sum() => SubPackets.Sum(p => p.CalculateValue());

        private long Product()
        {
            long value = SubPackets[0].CalculateValue();
            for(int i = 1; i < SubPackets.Count; i++)
                value *= SubPackets[i].CalculateValue();
            return value;
        }

        private long Minimum() => SubPackets.Min(p => p.CalculateValue());

        private long Maximum() => SubPackets.Max(p => p.CalculateValue());

        private int GreaterThan() =>
            SubPackets[0].CalculateValue() > SubPackets[1].CalculateValue() ? 1 : 0;

        private int LessThan() =>
            SubPackets[0].CalculateValue() < SubPackets[1].CalculateValue() ? 1 : 0;

        private int EqualTo() =>
            SubPackets[0].CalculateValue() == SubPackets[1].CalculateValue() ? 1 : 0;

        public static Packet ParsePacket(string binary, ref int offset)
        {
            Packet packet = new Packet();

            // Version
            packet.Version = BinaryStringToInt(binary.Substring(offset, 3));
            offset += 3;

            // TypeId
            packet.TypeId = BinaryStringToInt(binary.Substring(offset, 3));
            offset += 3;

            switch(packet.TypeId)
            {
                case 4:
                    offset = packet.ParseLiteralPacket(binary, offset);
                    break;
                default:    // Operator
                    offset = packet.ParseOperatorPacket(binary, offset);
                    break;
            }

            return packet;
        }

        private int ParseLiteralPacket(string binary, int offset)
        {
            while(binary[offset] == '1')
            {
                offset = ParseLiteralPart(binary, offset);
            }
            return ParseLiteralPart(binary, offset);
        }

        private int ParseLiteralPart(string binary, int offset)
        {
            LiteralValue = LiteralValue << 4;
            LiteralValue |= BinaryStringToInt(binary.Substring(offset + 1, 4));
            offset += 5;
            return offset;
        }

        private int ParseOperatorPacket(string binary, int offset)
        {
            // Length Type ID
            LengthTypeId = BinaryStringToInt(binary.Substring(offset, 1));
            offset++;

            // Length
            int len = LengthTypeId == 0 ? 15 : 11;
            LengthOrNumberOfSubPackets = BinaryStringToInt(binary.Substring(offset, len));
            offset += len;

            return LengthTypeId == 0 ?
                ParseOperatorPacketByLength(binary, offset) :
                ParseOperatorPacketByNumberOfPackets(binary, offset);
        }

        private int ParseOperatorPacketByLength(string binary, int offset)
        {
            int endOffset = offset + LengthOrNumberOfSubPackets;
            while(offset < endOffset)
            {
                SubPackets.Add(ParsePacket(binary, ref offset));
            }
            return offset;
        }

        private int ParseOperatorPacketByNumberOfPackets(string binary, int offset)
        {
            for (int i = 0; i < LengthOrNumberOfSubPackets; i++)
                SubPackets.Add(ParsePacket(binary, ref offset));

            return offset;
        }
    }

    internal static IEnumerable<byte> ParseHex(string line)
    {
        var bytes = new List<byte>();

        for(int i = 0; i < line.Length; i += 2)
        {
            string b = i < line.Length - 1 ? 
                line.Substring(i, 2) :
                line.Substring(i, 1) + "0";
            bytes.Add(Convert.ToByte(b, 16));
        }

        return bytes;
    }

    internal static string HexToBinaryString(IEnumerable<byte> bytes) =>
        string.Join("", bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).ToArray() );

    internal static int BinaryStringToInt(string binary) =>
        Convert.ToInt32(binary, 2);
}
