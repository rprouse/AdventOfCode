using AdventOfCode.Core;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022;

[Parallelizable(ParallelScope.All)]
public class Day06Tests : TestBase
{
    const int DAY = 06;

    [Test]
    public void TestPartOne()
    {
        Day06.PartOne(PuzzleFile(DAY)).Should().Be(1361);
    }

    [Test]
    public void TestPartTwo()
    {
        Day06.PartTwo(PuzzleFile(DAY)).Should().Be(3263);
    }

    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void TestCasePartOne(string text, int expected)
    {
        Day06.FindFirstPacket(text, Day06.StartPacketSize).Should().Be(expected);
    }

    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void TestCasePartTwo(string text, int expected)
    {
        Day06.FindFirstPacket(text, Day06.MessagePacketSize).Should().Be(expected);
    }
}
