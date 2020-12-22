using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day22
    {
        public static int PartOne(string filename)
        {
            // Parse
            string[] lines = filename.ReadAllLines();
            LinkedList<int> player1 = new LinkedList<int>();
            LinkedList<int> player2 = new LinkedList<int>();
            LinkedList<int> current = player1;
            foreach(string line in lines)
            {
                if (line == "Player 1:")
                    current = player1;
                else if (line == "Player 2:")
                    current = player2;
                else
                    current.AddLast(line.ToInt());
            }

            // Play
            while(player1.Count > 0 && player2.Count > 0)
            {
                int card1 = player1.First.Value;
                player1.RemoveFirst();

                int card2 = player2.First.Value;
                player2.RemoveFirst();

                if(card1 > card2)
                {
                    player1.AddLast(card1);
                    player1.AddLast(card2);
                }
                else
                {
                    player2.AddLast(card2);
                    player2.AddLast(card1);
                }
            }

            // Score
            var winner = player1.Count > 0 ? player1 : player2;
            int score = 0;
            int count = 1;
            while(winner.Count > 0)
            {
                int card = winner.Last.Value;
                winner.RemoveLast();

                score += card * count++;
            }

            return score;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
