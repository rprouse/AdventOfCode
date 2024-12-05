namespace AdventOfCode2024;

public static class Day05
{
    public static int PartOne(string filename)
    {
        string[] lines = filename.ReadAllLines();

        // Parse input
        Dictionary<int, List<int>> rules = new();
        List<int[]> updates = new();
        foreach (string line in lines)
        {
            if (line.Length == 5 && line[2] == '|')
            {
                int a = int.Parse(line.Substring(0, 2));
                int b = int.Parse(line.Substring(3, 2));
                if (!rules.ContainsKey(a))
                {
                    rules[a] = new List<int>();
                }
                rules[a].Add(b);
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                var pages = line.Split(',').Select(int.Parse).ToArray();
                updates.Add(pages);
            }
        }

        // Process updates
        int sum = 0;
        foreach (var update in updates)
        {
            bool valid = true;
            for (int i = update.Length - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (rules.ContainsKey(update[i]) && rules[update[i]].Contains(update[j]))
                    {
                        valid = false;
                        break;
                    }
                }
                if (!valid) break;
            }
            if (valid)
            {
                sum += update[update.Length/2];
            }        
        }

        return sum;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
