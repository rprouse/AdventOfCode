namespace AdventOfCode2024;

[Parallelizable(ParallelScope.All)]
public class Day02Tests : TestBase
{
    const int DAY = 02;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day02.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day02.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 2);
        yield return new TestCaseData(PuzzleFile(DAY), 526);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 4);
        yield return new TestCaseData(PuzzleFile(DAY), 566);
    }
}
