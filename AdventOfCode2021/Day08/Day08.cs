using System;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

//   0:      1:      2:      3:      4:
// aaaa    ....    aaaa    aaaa    ....
//b    c  .    c  .    c  .    c  b    c
//b    c  .    c  .    c  .    c  b    c
// ....    ....    dddd    dddd    dddd
//e    f  .    f  e    .  .    f  .    f
//e    f  .    f  e    .  .    f  .    f
// gggg    ....    gggg    gggg    ....

//  5:      6:      7:      8:      9:
// aaaa    aaaa    aaaa    aaaa    aaaa
//b    .  b    .  .    c  b    c  b    c
//b    .  b    .  .    c  b    c  b    c
// dddd    dddd    ....    dddd    dddd
//.    f  e    f  .    f  e    f  .    f
//.    f  e    f  .    f  e    f  .    f
// gggg    gggg    ....    gggg    gggg
public static class Day08
{
    public static int PartOne(string filename)
    {
        string[] lines = filename.ReadAllLines();
        int count = 0;
        foreach (string line in lines)
        {
            (_, string[] outputs) = ParseLine(line);
            count += outputs.Count(o => o.Length == 2 ||
                o.Length == 4 ||
                o.Length == 3 ||
                o.Length == 7);
        }
        return count;
    }

    public static int PartTwo(string filename) =>
        filename.ReadAllLines()
            .Sum(l =>
            {
                (string[] inputs, string[] outputs) = ParseLine(l);
                return DetermineOutput(inputs, outputs);
            });

    internal static (string[] inputs, string[] outputs) ParseLine(string line)
    {
        string[] parts = line.Split(" | ");
        string[] input = parts[0].Split(' ');
        string[] output = parts[1].Split(' ');
        return (input, output);
    }

    internal static int DetermineOutput(string[] inputs, string[] outputs)
    {
        var mappings = GetMappings(inputs).ToList();

        int result = 0;
        for (int i = 0; i < outputs.Length; i++)
        {
            string digit = outputs[3 - i];
            string map = mappings.Single(m => digit.Length == m.Length && m.All(c => digit.Contains(c)));
            int value = mappings.IndexOf(map);
            int power = (int)Math.Pow(10, i);
            result += value * power;
        }
        return result;
    }

    internal static string[] GetMappings(string[] inputs)
    {
        string[] mappings = new string[10];

        // Ones have 2 segments c and f
        mappings[1] = inputs.Single(i => i.Length == 2);

        // Sevens have 3 segments a, c and f
        mappings[7] = inputs.Single(i => i.Length == 3);

        // Fours have 4 segments b, c, d and f
        mappings[4] = inputs.First(i => i.Length == 4);

        // Eights have 7 segments a, b, c, d, e, f and g
        mappings[8] = inputs.First(i => i.Length == 7);

        // Threes have 5 segments a, c, d, f and g
        // and are common with seven
        mappings[3] = inputs.First(i => i.Length == 5 &&
            mappings[7].IsSubsetOf(i));

        // Sixes have 6 segments a, b, d, e, f and g
        // and are not common with seven
        mappings[6] = inputs.First(i => i.Length == 6 &&
            !mappings[7].IsSubsetOf(i));

        // Fives have 5 segments a, b, d, f and g,
        // are not 3
        // and have all segments in common with 6
        mappings[5] = inputs.First(i => i.Length == 5 &&
            i != mappings[3] &&
            mappings[6].IsSupersetOf(i));

        // Twos have 5 segments a, c, d, e and g
        // and are not 3 or 5
        mappings[2] = inputs.First(i => i.Length == 5 &&
            i != mappings[3] &&
            i != mappings[5]);

        // Nines have 6 segments a, b, c, d, f and g
        // and are not 6
        // and have segments in common with 4
        mappings[9] = inputs.First(i => i.Length == 6 &&
            i != mappings[6] &&
            mappings[4].IsSubsetOf(i));

        // Zeros have 6 segments a, b, c, e, f and g
        // and are not 6 or 9
        mappings[0] = inputs.First(i => i.Length == 6 &&
            i != mappings[6] &&
            i != mappings[9]);

        return mappings;
    }
}
