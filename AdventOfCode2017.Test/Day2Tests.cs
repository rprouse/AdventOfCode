using System.Collections;
using NUnit.Framework;

namespace AdventOfCode2017.Test
{
    public class Day2Tests
    {
        [TestCaseSource(nameof(Day2Data))]
        public void TestChecksum(int[][] spreadsheet, int expected)
        {
            Assert.That(Day2.Checksum(spreadsheet), Is.EqualTo(expected));
        }

        public static IEnumerable Day2Data()
        {
            yield return new TestCaseData(
                new int[][]
                {
                    new int[] { 5,1,9,5 },
                    new int[] { 7,5,3 },
                    new int[] { 2,4,6,8 }
                }
                , 18
                );
        }
    }
}
