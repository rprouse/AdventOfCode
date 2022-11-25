using System;
using System.Collections;
using System.IO;
using AdventOfCode.Core;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode2015;

public class Day16Tests : TestBase
{
    const int DAY = 16;

    [Test]
    public void TestPartOne()
    {
        Day16.PartOne(PuzzleFile(DAY)).Should().Be(103);
    }

    [Test]
    public void TestPartTwo()
    {
        Day16.PartTwo(PuzzleFile(DAY)).Should().Be(405);
    }
}
