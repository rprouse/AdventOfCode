using AdventOfCode.Core;

namespace AdventOfCode2015;

public static class Day18
{
    public static int PartOne(string filename, int steps)
    {
        var life = new ConwaysGameOfLife(filename);
        for(int step = 0; step < steps; step++) 
        {
            life.Step();
        }
        return life.CountAlive();
    }

    public static int PartTwo(string filename, int steps)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
