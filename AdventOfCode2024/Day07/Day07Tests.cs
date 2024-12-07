namespace AdventOfCode2024;

[Parallelizable(ParallelScope.All)]
public class Day07Tests : TestBase
{
    const int DAY = 07;

    [Test]
    public void CanConstructCalibration()
    {
        var calibration = new Calibration("3267: 81 40 27");
        calibration.Value.Should().Be(3267);
        calibration.Inputs.Should().BeEquivalentTo([81, 40, 27]);
    }

    [TestCase("190: 10 19", true)]
    [TestCase("3267: 81 40 27", true)]
    [TestCase("83: 17 5", false)]
    [TestCase("156: 15 6", false)]
    [TestCase("7290: 6 8 6 15", false)]
    [TestCase("161011: 16 10 13", false)]
    [TestCase("192: 17 8 14", false)]
    [TestCase("21037: 9 7 18 13", false)]
    [TestCase("292: 11 6 16 20", true)]
    public void CanDetermineIfValidWithMultiplicationAndDivision(string text, bool expected)
    {
        var calibration = new Calibration(text);
        calibration.ValidWithAdditionAndMultiplication().Should().Be(expected);
    }

    [TestCase("190: 10 19", true)]
    [TestCase("3267: 81 40 27", true)]
    [TestCase("83: 17 5", false)]
    [TestCase("156: 15 6", true)]
    [TestCase("7290: 6 8 6 15", true)]
    [TestCase("161011: 16 10 13", false)]
    [TestCase("192: 17 8 14", true)]
    [TestCase("21037: 9 7 18 13", false)]
    [TestCase("292: 11 6 16 20", true)]
    public void CanDetermineIfValidWithMultiplicationDivisionAndConcatination(string text, bool expected)
    {
        var calibration = new Calibration(text);
        calibration.ValidWithAdditionMultiplicationAndConcatination().Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, ulong expected)
    {
        Day07.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, ulong expected)
    {
        Day07.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 3749UL);
        yield return new TestCaseData(PuzzleFile(DAY), 3245122495150UL);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 11387UL);
        yield return new TestCaseData(PuzzleFile(DAY), 105517128211543UL);
    }
}
