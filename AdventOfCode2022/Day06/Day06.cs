using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day06
{
    public static int PartOne(string filename) =>
        FindStartPacket(filename.ReadFirstLine());

    internal static int FindStartPacket(string text)
    {
        int i = 3;
        for(; i < text.Length; i++)
        {
            if (text[i] != text[i-1] &&
                text[i] != text[i - 2] &&
                text[i] != text[i - 3] &&
                text[i - 1] != text[i - 2] &&
                text[i - 1] != text[i - 3] &&
                text[i - 2] != text[i - 3]
                )
                return i + 1;
        }
        return -1;
    }

    public static int PartTwo(string filename) =>
        FindMessagePacket(filename.ReadFirstLine());

    internal static int FindMessagePacket(string text)
    {
        int i = 14;
        for (; i < text.Length; i++)
        {
            bool match = false;
            for (int a = i - 13; a < i; a++)
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
