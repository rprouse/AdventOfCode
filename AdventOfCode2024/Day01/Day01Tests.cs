namespace AdventOfCode2024;

[Parallelizable(ParallelScope.All)]
public class Day01Tests : TestBase
{
    const int DAY = 01;

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day01.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day01.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 11);
        yield return new TestCaseData(PuzzleFile(DAY), 1341714);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 31);
        yield return new TestCaseData(PuzzleFile(DAY), 27384707);
    }
}
