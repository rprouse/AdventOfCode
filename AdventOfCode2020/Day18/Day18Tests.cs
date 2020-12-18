using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2020
{
    [Parallelizable(ParallelScope.All)]
    public class Day18Tests : TestBase
    {
        const int DAY = 18;

        [Test]
        public void TestPartOne()
        {
            Day18.PartOne(PuzzleFile(DAY)).Should().Be(21022630974613L);
        }

        [Test]
        public void TestPartTwo()
        {
            Day18.PartTwo(PuzzleFile(DAY)).Should().Be(169899524778212L);
        }

        [TestCase("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [TestCase("2 * 3 + (4 * 5)", 26)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void CanEvaluateLinePartOne(string equation, long expected)
        {
            Day18.EvaluatePartOne(equation).Should().Be(expected);
        }

        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 4, 10)]
        [TestCase("2 * 3 + (4 * 5)", 8, 14)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 4, 26)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 29, 39)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 1, 11)]
        public void CanFindInnermostParens(string equation, int exStart, int exEnd)
        {
            (int start, int end) = Day18.FindInnermostParens(equation);
            start.Should().Be(exStart);
            end.Should().Be(exEnd);
        }

        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 4, 10, "2 * 3")]
        [TestCase("2 * 3 + (4 * 5)", 8, 14, "4 * 5")]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 4, 26, "8 * 3 + 9 + 3 * 4 * 3")]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 29, 39, "8 + 6 * 4")]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 1, 11, "2 + 4 * 9")]
        public void CanGetInnerEquation(string equation, int start, int end, string expected)
        {
            Day18.GetInnerEquation(equation, start, end).Should().Be(expected);
        }

        [TestCase("2 * 3", 6)]
        [TestCase("4 * 5", 20)]
        [TestCase("8 * 3 + 9 + 3 * 4 * 3", 432)]
        [TestCase("8 + 6 * 4", 56)]
        [TestCase("2 + 4 * 9", 54)]
        [TestCase("1 + 2 * 3 + 4 * 5 + 6", 71)]
        public void CanEvaluateWithoutParens(string equation, long expected)
        {
            Day18.EvaluateWithoutParens(equation).Should().Be(expected);
        }

        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 6, 4, 10, "1 + 6 + (4 * (5 + 6))")]
        [TestCase("2 * 3 + (4 * 5)", 20, 8, 14, "2 * 3 + 20")]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 432, 4, 26, "5 + 432")]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 56, 29, 39, "5 * 9 * (7 * 3 * 3 + 9 * 3 + 56)")]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 54, 1, 11, "(54 * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2")]
        public void CanSubsituteInnerWithResult(string equation, long result, int start, int end, string expected)
        {
            Day18.SubsituteInnerWithResult(equation, result, start, end).Should().Be(expected);
        }

        [TestCase("2 * 3", 6)]
        [TestCase("4 * 5", 20)]
        [TestCase("8 * 3 + 9 + 3 * 4 * 3", 1440)]
        [TestCase("8 + 6 * 4", 56)]
        [TestCase("2 + 4 * 9", 54)]
        [TestCase("1 + 2 * 3 + 4 * 5 + 6", 231)]
        public void CanEvaluateWithoutParensAndPrecedence(string equation, long expected)
        {
            Day18.EvaluateWithoutParensAndPrecedence(equation).Should().Be(expected);
        }

        [TestCase("1 + 2 * 3 + 4 * 5 + 6", 231)]
        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [TestCase("2 * 3 + (4 * 5)", 46)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        public void CanEvaluateLinePartTwo(string equation, long expected)
        {
            Day18.EvaluatePartTwo(equation).Should().Be(expected);
        }
    }
}
