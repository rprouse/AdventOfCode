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
        const int ITERATIONS_A = 40000000;
        const int ITERATIONS_B = 5000000;

        delegate void ActionRef(ref int arg1, ref int arg2);

        public static int PartOne(int seedA, int seedB, int iterations = ITERATIONS_A) =>
            Generator(seedA, seedB, iterations, (ref int a, ref int b) => {
                a = Generate(a, FACTOR_A);
                b = Generate(b, FACTOR_B);
            });

        public static int PartTwo(int seedA, int seedB) =>
            Generator(seedA, seedB, ITERATIONS_B, (ref int a, ref int b) => {
                a = GenerateWithCriteria(a, FACTOR_A, 4);
                b = GenerateWithCriteria(b, FACTOR_B, 8);
            });

        static int Generator(int seedA, int seedB, int iterations, ActionRef generate)
        {
            int count = 0;
            for (int i = 0; i < iterations; i++)
            {
                generate(ref seedA, ref seedB);
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
