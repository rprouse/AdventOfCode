using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day22
    {
        public static int PartOne(string filename)
        {
            var cards = new SpaceCards(10007);
            cards.Shuffle(filename);
            for(int i = 0; i < 10007; i++)
                if(cards.Cards[i] == 2019)
                    return i;
            return -1;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }

    public class SpaceCards
    {
        int[] _stack;

        public int[] Cards { get; private set; }

        public SpaceCards(int deckSize)
        {
            Cards = new int[deckSize];
            _stack = new int[deckSize];
            for(int i = 0; i < deckSize; i++)
            {
                Cards[i] = i;
            }
        }

        public void Shuffle(string filename)
        {
            string[] lines = filename.ReadAllLines();
            foreach(var line in lines)
            {
                if(line == "deal into new stack")
                {
                    DealIntoNewStack();
                }
                else if(line.StartsWith("cut"))
                {
                    int n = line.Substring(4).ToInt();
                    CutCards(n);
                }
                else if(line.StartsWith("deal with increment"))
                {
                    int n = line.Substring(20).ToInt();
                    DealWithIncrement(n);
                }
                else
                {
                    throw new ArgumentException($"Unknown command {line}");
                }
            }
        }

        public void DealIntoNewStack()
        {
            for (int i = 0; i < Cards.Length; i++)
                _stack[i] = Cards[Cards.Length - i - 1];

            SwapStacks();
        }

        public void CutCards(int n)
        {
            if(n >= 0)
            {
                Array.Copy(Cards, 0, _stack, Cards.Length - n, n);
                Array.Copy(Cards, n, _stack, 0, Cards.Length - n);
            }
            else
            {
                n = Math.Abs(n);
                Array.Copy(Cards, Cards.Length - n, _stack, 0, n);
                Array.Copy(Cards, 0, _stack, n, Cards.Length - n);
            }
            SwapStacks();
        }

        public void DealWithIncrement(int n)
        {
            for (int i = 0; i < Cards.Length; i++)
                _stack[i * n % Cards.Length] = Cards[i];
            SwapStacks();
        }

        void SwapStacks()
        {
            var temp = Cards;
            Cards = _stack;
            _stack = temp;
        }
    }
}
