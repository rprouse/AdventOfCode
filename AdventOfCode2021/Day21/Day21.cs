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

    public static long PartTwo(int p1, int p2)
    {
        long wins1 = 0;
        long wins2 = 0;
        QuantumRoll(0, 0, p1, p2, ref wins1, ref wins2);
        return Math.Max(wins1, wins2);
    }

    static void QuantumRoll(int score1, int score2, int player1, int player2, ref long wins1, ref long wins2)
    {
        if (score2 >= 21)
        {
            wins2++;
            return;
        }
        int p1 = (player1 + 1 - 1) % 10 + 1;
        int s1 = score1 + p1;
        QuantumRoll(score2, s1, player2, p1, ref wins2, ref wins1);
        int p2 = (player1 + 2 - 1) % 10 + 1;
        int s2 = score1 + p2;
        QuantumRoll(score2, s2, player2, p2, ref wins2, ref wins1);
        int p3 = (player1 + 3 - 1) % 10 + 1;
        int s3 = score1 + p3;
        QuantumRoll(score2, s3, player2, p3, ref wins2, ref wins1);
    }
}
