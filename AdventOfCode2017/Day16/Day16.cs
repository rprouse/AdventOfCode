using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day16
    {
        public static string PartOne(string str)
        {
            string[] dance = str.Trim().Split(",");
            string programs = Create(16);
            foreach(string step in dance)
            {
                switch(step[0])
                {
                    case 's':
                        programs = programs.Spin(ParseSpin(step));
                        break;
                    case 'x':
                        var ex = ParseExchange(step);
                        programs = programs.Exchange(ex.a, ex.b);
                        break;
                    case 'p':
                        var pr = ParsePartner(step);
                        programs = programs.Partner(pr.a, pr.b);
                        break;
                }
            }
            return programs;
        }

        public static int PartTwo(string str)
        {
            return 0;
        }

        public static string Create(int length) =>
            new string(Enumerable.Range('a', length).Select(i => (char)i).ToArray());

        public static int ParseSpin(string spin)
        {
            int s = 0;
            int.TryParse(spin.Substring(1), out s);
            return s;
        }

        public static (int a, int b) ParseExchange(string exchange)
        {
            int a = 0;
            int b = 0;
            string[] split = exchange.Substring(1).Split('/');
            int.TryParse(split[0], out a);
            int.TryParse(split[1], out b);
            return (a, b);
        }

        public static (char a, char b) ParsePartner(string partner)
        {
            string[] split = partner.Substring(1).Split('/');
            return (split[0][0], split[1][0]);
        }

        public static string Spin(this string programs, int x) =>
            programs.Substring(programs.Length - x) + programs.Substring(0, programs.Length - x);

        public static string Exchange(this string programs, int a, int b)
        {
            char[] array = programs.ToArray();
            char cA = array[a];
            array[a] = array[b];
            array[b] = cA;
            return new string(array);
        }

        public static string Partner(this string programs, char a, char b) =>
            programs.Exchange(programs.IndexOf(a), programs.IndexOf(b));
    }
}
