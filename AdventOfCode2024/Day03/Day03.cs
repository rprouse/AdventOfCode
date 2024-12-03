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

        return SumMultiples(text);
    }

    public static int PartTwo(string filename)
    {
        string text = string.Join("", filename.ReadAllLines());

        // Find the do() and don't() conditionals, strip out the don't()s, and return the sum of the do()s
        bool enabled = true;
        int current = 0;
        StringBuilder sb = new ();
        int pos = text.IndexOf("do");
        while (pos >= 0)
        {
            if (text.Substring(pos, 4) == "do()")
            {
                if (enabled)
                {
                    sb.Append(text.Substring(current, pos - current));
                }
                enabled = true;
                current = pos + 4;
                pos += 4;
            }
            else if (text.Substring(pos, 7) == "don't()")
            {
                if (enabled)
                {
                    sb.Append(text.Substring(current, pos - current));
                }
                enabled = false;
                current = pos + 7;
                pos += 7;
            }
            else
            {
                pos += 2;
            }
            pos = text.IndexOf("do", pos);
        }
        if (enabled)
        {
            sb.Append(text.Substring(current));
        }

        return SumMultiples(sb.ToString());
    }

    private static int SumMultiples(string text)
    {
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
}
