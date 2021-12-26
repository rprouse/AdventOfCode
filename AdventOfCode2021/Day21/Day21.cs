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
        var outcomes = new Dictionary<int, long>();

        for (int x = 1; x <= 3; x++)
        {
            for (int y = 1; y <= 3; y++)
            {
                for (int z = 1; z <= 3; z++)
                {
                    int outcome = x + y + z;
                    if (outcomes.ContainsKey(outcome))
                        outcomes[outcome]++;
                    else
                        outcomes[outcome] = 1;
                }
            }
        }

        long wins1 = 0;
        long wins2 = 0;
        QuantumRoll(0, 0, p1, p2, ref wins1, ref wins2, 1);
        return Math.Max(wins1, wins2);

        void QuantumRoll(int score1, int score2, int player1, int player2, ref long wins1, ref long wins2, long universes)
        {
            foreach (var kvp in outcomes)
            {
                int p1 = Move(player1, kvp.Key);
                int s1 = score1 + p1;

                if (s1 < 21)
                    QuantumRoll(score2, s1, player2, p1, ref wins2, ref wins1, kvp.Value * universes);
                else
                    wins2 += universes * kvp.Value;
            }
        }
    }

    static int Move(int position, int spaces) =>
        (position + spaces - 1) % 10 + 1;
}
