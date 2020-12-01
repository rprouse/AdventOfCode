using System.IO;

namespace AdventOfCode.Core
{
    public class TestBase
    {
        public static string TestFile(int day, string filename = "Test.txt") =>
            Path.Combine($"Day{day:00}", filename);

        public static string PuzzleFile(int day, string filename = "Data.txt") =>
            Path.Combine($"Day{day:00}", filename);
    }
}
