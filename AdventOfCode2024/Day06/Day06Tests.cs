namespace AdventOfCode2024;

[Parallelizable(ParallelScope.All)]
public class Day06Tests : TestBase
{
    const int DAY = 06;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day06.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day06.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 41);
        yield return new TestCaseData(PuzzleFile(DAY), 5162);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 6);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
