namespace AdventOfCode.Core
{
    public class TestBase
    {
        public static string TestFile(int day, string filename = "Test.txt") =>
            $"Day{day:00}\\{filename}";

        public static string PuzzleFile(int day, string filename = "Data.txt") =>
            $"Day{day:00}\\{filename}";
    }
}
