namespace AdventOfCode2024;

public static class Day07
{
    public static ulong PartOne(string filename) =>
        ParseCalibrations(filename)
            .Where(c => c.ValidWithAdditionAndMultiplication())
            .Select(c => c.Value)
            .Aggregate(0UL, (total, next) => total + next);

    public static ulong PartTwo(string filename) =>
        ParseCalibrations(filename)
            .Where(c => c.ValidWithAdditionMultiplicationAndConcatination())
            .Select(c => c.Value)
            .Aggregate(0UL, (total, next) => total + next);

    private static Calibration[] ParseCalibrations(string filename) =>
        filename.ReadAllLines()
            .Select(line => new Calibration(line))
            .ToArray();
}
