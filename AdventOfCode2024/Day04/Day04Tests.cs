namespace AdventOfCode2024;

[Parallelizable(ParallelScope.All)]
public class Day04Tests : TestBase
{
    const int DAY = 04;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day04.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day04.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 18);
        yield return new TestCaseData(PuzzleFile(DAY), 2297);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 9);
        yield return new TestCaseData(PuzzleFile(DAY), 0);
    }
}
