using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day21
{
    public static int PartOne(int p1, int p2)
    {
        int rolls = 0;
        int dice = 0;
        int[] score = new int[2];
        int[] player = new int[2];
        player[0] = p1;
        player[1] = p2;
        while (true)
        {
            for (int p = 0; p < 2; p++)
            {
                player[p] += dice * 3 + 6;
                player[p] = (player[p] - 1) % 10 + 1;
                score[p] += player[p];
                rolls += 3;
                dice += 3;
                if (score[p] >= 1000)
                {
                    return rolls * score[(p + 1) % 2];
                }
            }
        }
    }

    public static int PartTwo(int p1, int p2)
    {
        return 0;
    }
}
