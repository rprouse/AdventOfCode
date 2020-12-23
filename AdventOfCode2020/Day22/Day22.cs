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
            (Queue<int> player1, Queue<int> player2) = Parse(filename);

            // Play
            while(player1.Count > 0 && player2.Count > 0)
            {
                int card1 = player1.Dequeue();
                int card2 = player2.Dequeue();

                if(card1 > card2)
                {
                    player1.Enqueue(card1);
                    player1.Enqueue(card2);
                }
                else
                {
                    player2.Enqueue(card2);
                    player2.Enqueue(card1);
                }
            }

            // Score
            var winner = player1.Count > 0 ? player1 : player2;
            return Score(winner);
        }

        public static int PartTwo(string filename)
        {
            (Queue<int> player1, Queue<int> player2) = Parse(filename);

            bool player1Won = PlayRecursive(player1, player2);

            return player1Won ? Score(player1) : Score(player2);
        }

        static bool SeenBefore(HashSet<string> previous, Queue<int> deck)
        {
            string deckStr = string.Join("+", deck.Select(d => d.ToString()));
            if(previous.Contains(deckStr))
            {
                return true;    // Seen before
            }
            previous.Add(deckStr);
            return false;
        }

        // Returns true if player 1 wins
        static bool PlayRecursive(Queue<int> player1, Queue<int> player2)
        {
            // I'm assuming we can use the score as a key for each deck?
            HashSet<string> player1Decks = new HashSet<string>();
            HashSet<string> player2Decks = new HashSet<string>();
            while (player1.Count > 0 && player2.Count > 0)
            {
                // Played this hand before?
                if (SeenBefore(player1Decks, player1))
                    return true;

                if (SeenBefore(player2Decks, player2))
                    return true;

                // Draw cards
                int card1 = player1.Dequeue();
                int card2 = player2.Dequeue();

                bool player1Won;
                if (player1.Count >= card1 && player2.Count >= card2)
                {
                    // Optimize, if player 1 has highest card in the current decks, they will win
                    int p1Max = player1.Max();
                    int p2Max = player2.Max();
                    if (p1Max > p2Max && p1Max > player1.Count + player2.Count)
                    {
                        player1Won = true;
                    }
                    else
                    {
                        // New game of recursive
                        var p1Copy = new Queue<int>(player1.Take(card1));
                        var p2Copy = new Queue<int>(player2.Take(card2));
                        player1Won = PlayRecursive(p1Copy, p2Copy);
                    }
                }
                else
                {
                    player1Won = card1 > card2;
                }

                // Add cards to winner's deck
                if (player1Won)
                {
                    // Player 1 wins round
                    player1.Enqueue(card1);
                    player1.Enqueue(card2);
                }
                else
                {
                    // Player 2 wins round
                    player2.Enqueue(card2);
                    player2.Enqueue(card1);
                }
            }
            return player1.Count > 0;
        }

        static (Queue<int> player1, Queue<int> player2) Parse(string filename)
        {
            // Parse
            string[] lines = filename.ReadAllLines();
            Queue<int> player1 = new Queue<int>();
            Queue<int> player2 = new Queue<int>();
            Queue<int> current = player1;
            foreach (string line in lines)
            {
                if (line == "Player 1:")
                    current = player1;
                else if (line == "Player 2:")
                    current = player2;
                else
                    current.Enqueue(line.ToInt());
            }
            return (player1, player2);
        }

        static int Score(Queue<int> deck)
        {

            int score = 0;
            int count = deck.Count;
            while (deck.Count > 0)
            {
                int card = deck.Dequeue();
                score += card * count--;
            }
            return score;
        }
    }
}
