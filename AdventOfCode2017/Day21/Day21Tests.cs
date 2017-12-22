using System.Collections;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2017
{
    public class Day21Tests : TestBase
    {
        const int DAY = 21;

        [TestCaseSource(nameof(TestDataOne))]
        public void TestPartOne(string filename, int iterations, int expected)
        {
            Assert.That(Day21.PartOne(filename, iterations), Is.EqualTo(expected));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.That(Day21.PartOne(PuzzleFile(DAY), 18), Is.EqualTo(2335049));
        }

        public static IEnumerable TestDataOne()
        {
            yield return new TestCaseData(TestFile(DAY), 2, 12);
            yield return new TestCaseData(PuzzleFile(DAY), 5, 190);
        }

        [TestCaseSource(nameof(MatrixChildren))]
        public void CanBreakupMatrix(string matrix, string[] children)
        {
            Assert.That(matrix.BreakupMatrix().ToArray(), Is.EqualTo(children));
        }

        [TestCaseSource(nameof(ChildrenMatrix))]
        public void CanJoinMatrixes(string[] children, string matrix)
        {
            Assert.That(children.JoinMatrixes(), Is.EqualTo(matrix));
        }

        public static IEnumerable MatrixChildren()
        {
            yield return new TestCaseData("###/..#/.#.", new[] { "###/..#/.#." });
            yield return new TestCaseData("####/..##/.#.#/..##", new[] { "##/..", "##/##", ".#/..", ".#/##" });
            yield return new TestCaseData("##.##./#..#../....../##.##./#..#../......", new[] { "##/#.", ".#/.#", "#./..", "../##", "../.#", "../#.", "#./..", ".#/..", "../.."});
        }

        public static IEnumerable ChildrenMatrix()
        {
            yield return new TestCaseData(new[] { "###/..#/.#." }, "###/..#/.#.");
            yield return new TestCaseData(new[] { "##/..", "##/##", ".#/..", ".#/##" }, "####/..##/.#.#/..##");
            yield return new TestCaseData(new[] { "##./#../...", "##./#../...", "##./#../...", "##./#../..." }, "##.##./#..#../....../##.##./#..#../......");
        }
    }
}
