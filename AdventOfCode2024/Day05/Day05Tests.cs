namespace AdventOfCode2024;

[Parallelizable(ParallelScope.All)]
public class Day05Tests : TestBase
{
    const int DAY = 05;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day05.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day05.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 143);
        yield return new TestCaseData(PuzzleFile(DAY), 6260);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 123);
        yield return new TestCaseData(PuzzleFile(DAY), 5346);
    }
}
