namespace AdventOfCode2024;

[Parallelizable(ParallelScope.All)]
public class Day03Tests : TestBase
{
    const int DAY = 03;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day03.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day03.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY, "Test1.txt"), 161);
        yield return new TestCaseData(PuzzleFile(DAY), 173529487);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY, "Test2.txt"), 48);
        yield return new TestCaseData(PuzzleFile(DAY), 99532691);
    }
}
