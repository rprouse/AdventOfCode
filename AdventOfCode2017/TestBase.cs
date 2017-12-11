namespace AdventOfCode2017
{
    public class TestBase
    {
        public static string TestFile(int day) => $"Day{day:00}\\Test.txt";

        public static string PuzzleFile(int day) => $"Day{day:00}\\Data.txt";
    }
}
