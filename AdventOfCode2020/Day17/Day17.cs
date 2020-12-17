namespace AdventOfCode2020
{
    public static class Day17
    {
        public static int PartOne(string filename)
        {
            var cubes = new ConwayCubes(filename, 6);
            cubes.Run();
            return cubes.CountActive();
        }

        public static int PartTwo(string filename)
        {
            var cubes = new ConwayHyperCubes(filename, 6);
            cubes.Run();
            return cubes.CountActive();
        }
    }
}
