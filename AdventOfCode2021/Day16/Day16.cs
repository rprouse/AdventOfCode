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
        return 0;
    }

    public static int PartTwo(string filename)
    {
        string line = filename.ReadAll();
        return 0;
    }

    internal class Packet
    {
        public int Version { get; private set; }
        public int TypeId { get; private set; }
        public int LiteralValue { get; private set; }
        public int LengthTypeId { get; private set; }
        public int NumberSubPackets { get; private set; }
        public List<Packet> SubPackets { get; } = new List<Packet>();

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
