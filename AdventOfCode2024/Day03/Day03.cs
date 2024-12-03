namespace AdventOfCode2024;

public static class Day03
{
    public static Regex part1_regex = new Regex(
        "mul\\((\\d+),(\\d+)\\)",
        RegexOptions.CultureInvariant
        | RegexOptions.Compiled
    );

    public static int PartOne(string filename)
    {
        string text = string.Join("", filename.ReadAllLines());

        int sum = 0;
        MatchCollection matches = part1_regex.Matches(text);
        foreach (var match in matches)
        {
            var m = (Match)match;
            int a = int.Parse(m.Groups[1].Value);
            int b = int.Parse(m.Groups[2].Value);
            sum += a * b;
        }
        return sum;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
