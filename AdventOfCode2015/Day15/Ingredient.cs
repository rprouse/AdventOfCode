using AdventOfCode.Core;

namespace AdventOfCode2015;

public class Ingredient
{
    public Ingredient(string line)
    {
        var p1 = line.Split(": ");
        Name = p1[0];
        var p2 = p1[1].Split(", ");
        Capacity = SplitOutInt(p2[0]);
        Durability = SplitOutInt(p2[1]);
        Flavor = SplitOutInt(p2[2]);
        Texture = SplitOutInt(p2[3]);
        Calories = SplitOutInt(p2[4]);
    }

    // string like "capacity -1"
    int SplitOutInt(string part) => part.Split(' ')[1].ToInt();

    public string Name { get; }
    public int Capacity { get; }
    public int Durability { get; }
    public int Flavor { get; }
    public int Texture { get; }
    public int Calories { get; }
}
