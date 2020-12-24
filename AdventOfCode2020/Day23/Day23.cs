using System;
using System.Linq;
using System.Text;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day23
    {
        public static string PartOne(string cupsStr, int moves, bool output = false)
        {
            var cups = new Cups(cupsStr, 9);
            cups.Play(moves, output);
            return cups.PartOneAnswer();
        }

        public static long PartTwo(string cupsStr)
        {
            var cups = new Cups(cupsStr, 1000000);
            cups.Play(1000000, false);
            return cups.PartTwoAnswer();
        }
    }

    public class Cups
    {
        readonly int _len;
        int[] _cups;
        int[] _newCups;

        public Cups(string cupsStr, int len)
        {
            _len = len;
            _cups = Enumerable.Range(0, _len).ToArray();
            Array.Copy(cupsStr.Select(c => c.ToString().ToInt() - 1).ToArray(), _cups, cupsStr.Length);
            _newCups = new int[_len];
        }

        public void Play(int moves, bool output = false)
        {
            foreach (int move in Enumerable.Range(0, moves))
            {
                int cup = Wrap(move);

                if (output || move % 1000 == 0)
                {
                    Console.Clear();
                    var b = new StringBuilder();
                    b.AppendLine($"-- move {move + 1} --");
                    b.Append("cups: ");
                    for (int i = 0; i < 9; i++)
                    {
                        bool current = cup == i;
                        if (current)
                            b.Append($"({_cups[i] + 1}) ");
                        else
                            b.Append($"{_cups[i] + 1} ");
                    }
                    b.AppendLine();
                    b.Append($"pick up: {_cups[Wrap(cup + 1)] + 1}, {_cups[Wrap(cup + 2)] + 1}, {_cups[Wrap(cup + 3)] + 1}");
                    Console.WriteLine(b.ToString());
                }

                // Find the destination
                int dest = Wrap(_cups[cup] - 1);
                while (dest == _cups[Wrap(cup + 1)] || dest == _cups[Wrap(cup + 2)] || dest == _cups[Wrap(cup + 3)])
                    dest = Wrap(dest - 1);

                // Where is the destination cup?
                int d = IndexOfCup(dest);

                // Copy the current cup
                _newCups[cup] = _cups[cup];

                // Copy the remaining cups across
                bool placingPickup = false;
                int pickup = cup + 1;
                int remaining = cup + 4;
                for (int c = cup + 1; c < cup + _len; c++)
                {
                    if (placingPickup)
                    {
                        _newCups[Wrap(c)] = _cups[Wrap(pickup++)];
                        if (pickup == cup + 4) placingPickup = false;
                        continue;
                    }
                    if (_cups[Wrap(remaining)] == dest)
                        placingPickup = true;
                    _newCups[Wrap(c)] = _cups[Wrap(remaining++)];
                }

                if (output || move % 10000 == 0)
                {
                    Console.WriteLine($"destination: {dest + 1}");
                    Console.WriteLine();
                }

                (_cups, _newCups) = (_newCups, _cups);
            }
        }

        internal int IndexOfCup(int cup)
        {
            for (int i = 0; i < _len; i++)
                if (_cups[i] == cup) return i;
            return -1;
        }

        internal int Wrap(int cup)
        {
            while (cup < 0)
                cup += _len;
            return cup % _len;
        }

        public string PartOneAnswer()
        {
            var result = new StringBuilder(_len - 1);
            var one = IndexOfCup(0);

            for (int c = one + 1; c < one + _len; c++)
            {
                result.Append(_cups[Wrap(c)] + 1);
            }
            return result.ToString();
        }

        public long PartTwoAnswer()
        {
            var one = IndexOfCup(0);
            return (_cups[Wrap(one + 1)] + 1L) * (_cups[Wrap(one + 1)] + 1L);
        }
    }
}
