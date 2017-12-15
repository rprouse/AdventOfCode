using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day15
    {
        const int FACTOR_A = 16807;
        const int FACTOR_B = 48271;
        const long DIVISOR = 2147483647;
        const int ITERATIONS = 40000000;

        public static int PartOne(int seedA, int seedB, int iterations = ITERATIONS)
        {
            int count = 0;
            for(int i = 0; i < iterations; i++)
            {
                seedA = Generate(seedA, FACTOR_A);
                seedB = Generate(seedB, FACTOR_B);
                if (LowerBitsMatch(seedA, seedB)) count++;
            }
            return count;
        }

        public static int PartTwo(int seedA, int seedB)
        {
            int count = 0;
            for (int i = 0; i < 5000000; i++)
            {
                seedA = GenerateWithCriteria(seedA, FACTOR_A, 4);
                seedB = GenerateWithCriteria(seedB, FACTOR_B, 8);
                if (LowerBitsMatch(seedA, seedB)) count++;
            }
            return count;
        }

        public static int Generate(long seed, long multiplier) =>
            (int)((seed * multiplier) % DIVISOR);

        public static bool LowerBitsMatch(int a, int b) =>
            (a & 0xFFFF) == (b & 0xFFFF);

        public static int GenerateWithCriteria(int seed, int multiplier, int divisor)
        {
            do
            {
                seed = Generate(seed, multiplier);
            }
            while (seed % divisor != 0);
            return seed;
        }
    }
}
