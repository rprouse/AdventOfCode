namespace AdventOfCode2024;

public static class Day05
{
    public static int PartOne(string filename)
    {
        Dictionary<int, List<int>> rules;
        List<int[]> updates;
        ParseInputData(filename, out rules, out updates);

        // Process updates
        return FilterValidUpdates(rules, updates, true).Sum(update => update[update.Length / 2]);
    }

    public static int PartTwo(string filename)
    {
        Dictionary<int, List<int>> rules;
        List<int[]> updates;
        ParseInputData(filename, out rules, out updates);

        // Process updates
        int sum = 0;
        foreach (var update in FilterValidUpdates(rules, updates, false))
        {
            // Put the update into the correct order
            Array.Sort(update, (a, b) => {
                if (rules.ContainsKey(a) && rules[a].Contains(b)) return -1;
                if (rules.ContainsKey(b) && rules[b].Contains(a)) return 1;
                return 0;
            });
            sum += update[update.Length / 2];
        }
        return sum;
    }

    private static IEnumerable<int[]> FilterValidUpdates(Dictionary<int, List<int>> rules, List<int[]> updates, bool returnValid)
    {
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
                if (!valid)
                {
                    if (!returnValid)
                    {
                        yield return update;
                    }
                    break;
                }
            }
            if (valid && returnValid)
            {
                yield return update;
            }
        }
    }

    private static void ParseInputData(string filename, out Dictionary<int, List<int>> rules, out List<int[]> updates)
    {
        // Parse input
        string[] lines = filename.ReadAllLines();
        rules = new();
        updates = new();
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
    }
}
