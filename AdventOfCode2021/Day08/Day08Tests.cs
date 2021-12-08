using System.Collections;
using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2021;

[Parallelizable(ParallelScope.All)]
public class Day08Tests : TestBase
{
    const int DAY = 08;

    [Test]
    public void TestGetMappings()
    {
        string[] mappings = Day08.GetMappings(new[] { "acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab" });
        mappings[0].Should().Be("cagedb");
        mappings[1].Should().Be("ab");
        mappings[2].Should().Be("gcdfa");
        mappings[3].Should().Be("fbcad");
        mappings[4].Should().Be("eafb");
        mappings[5].Should().Be("cdfbe");
        mappings[6].Should().Be("cdfgeb");
        mappings[7].Should().Be("dab");
        mappings[8].Should().Be("acedgfb");
        mappings[9].Should().Be("cefabd");
    }

    [TestCase("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf", 5353)]
    [TestCase("be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe", 8394)]
    [TestCase("edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", 9781)]
    [TestCase("fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg", 1197)]
    [TestCase("fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb", 9361)]
    [TestCase("aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea", 4873)]
    [TestCase("fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb", 8418)]
    [TestCase("dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe", 4548)]
    [TestCase("bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef", 1625)]
    [TestCase("egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb", 8717)]
    [TestCase("gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce", 4315)]
    public void TestDetermineOutput(string line, int expected)
    {
        (string[] inputs, string[] outputs) = Day08.ParseLine(line);
        Day08.DetermineOutput(inputs, outputs).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataOne))]
    public void TestPartOne(string filename, int expected)
    {
        Day08.PartOne(filename).Should().Be(expected);
    }

    [TestCaseSource(nameof(TestDataTwo))]
    public void TestPartTwo(string filename, int expected)
    {
        Day08.PartTwo(filename).Should().Be(expected);
    }

    public static IEnumerable TestDataOne()
    {
        yield return new TestCaseData(TestFile(DAY), 26);
        yield return new TestCaseData(PuzzleFile(DAY), 344);
    }

    public static IEnumerable TestDataTwo()
    {
        yield return new TestCaseData(TestFile(DAY), 61229);
        yield return new TestCaseData(PuzzleFile(DAY), 1048410);
    }
}
