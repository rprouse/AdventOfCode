using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day06
{
    internal const int StartPacketSize = 4;
    internal const int MessagePacketSize = 14;

    public static int PartOne(string filename) =>
        FindFirstPacket(filename.ReadFirstLine(), StartPacketSize);

    public static int PartTwo(string filename) =>
        FindFirstPacket(filename.ReadFirstLine(), MessagePacketSize);

    internal static int FindFirstPacket(string text, int packetSize)
    {
        for (int i = packetSize; i < text.Length; i++)
        {
            bool match = false;
            for (int a = i - packetSize + 1; a < i; a++)
            {
                for (int b = a + 1; b <= i; b++)
                {
                    if (text[a] == text[b])
                    {
                        match = true;
                        break;
                    }
                }
            }
            if (!match) return i + 1;
        }
        return -1;
    }
}
