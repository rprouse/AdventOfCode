using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day25
    {
        public static long PartOne(long cardKey, long doorKey)
        {
            int cardLoopSize = GetLoopSizeForKey(cardKey);
            return CalculateEncryptionKey(doorKey, cardLoopSize);
        }

        public static int PartTwo()
        {
            return 0;
        }

        static internal long CalculateEncryptionKey(long publicKey, int loopsize)
        {
            long result = 1;
            for (int i = 0; i < loopsize; i++)
            {
                result *= publicKey;
                result %= 20201227;
            }
            return result;
        }

        static internal int GetLoopSizeForKey(long publicKey)
        {
            long result = 1;
            int count = 0;
            while(result != publicKey)
            {
                count++;
                result *= 7;
                result %= 20201227;
            }
            return count;
        }
    }
}
