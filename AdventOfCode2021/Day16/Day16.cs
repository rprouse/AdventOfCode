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
        return 0;
    }

    public static int PartTwo(string filename)
    {
        string line = filename.ReadAll();
        return 0;
    }

    internal static IList<byte> ParseHex(string line)
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
}
