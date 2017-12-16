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
            char[] programs = Create(16);

            return new string(Dance(programs, dance));
        }

        public static string PartTwo(string str)
        {
            string[] dance = str.Trim().Split(",");
            char[] first = Create(16);
            char[] programs = Create(16);
            int i = 0;
            while(true)
            {
                i++;
                Dance(programs, dance);
                if (Enumerable.SequenceEqual(first, programs)) break;
            }
            foreach(var x in Enumerable.Range(0, 1000000000 % i))
            {
                Dance(programs, dance);
            }

            return new string(programs);
        }

        private static char[] Dance(char[] programs, string[] dance)
        {
            foreach (string step in dance)
            {
                switch (step[0])
                {
                    case 's':
                        programs.Spin(ParseSpin(step));
                        break;
                    case 'x':
                        var ex = ParseExchange(step);
                        programs.Exchange(ex.a, ex.b);
                        break;
                    case 'p':
                        var pr = ParsePartner(step);
                        programs.Partner(pr.a, pr.b);
                        break;
                }
            }
            return programs;
        }

        public static char[] Create(int length) =>
            Enumerable.Range('a', length).Select(i => (char)i).ToArray();

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

        static char[] first = new char[16];
        static char[] second = new char[16];
        static int len;

        public static void Spin(this char[] programs, int x)
        {
            len = programs.Length - x;
            Array.Copy(programs, first, len);
            Array.Copy(programs, len, second, 0, x);
            Array.Copy(second, programs, x);
            Array.Copy(first, 0, programs, x, len);
        }

        static char cA;
        public static void Exchange(this char[] programs, int a, int b)
        {
            cA = programs[a];
            programs[a] = programs[b];
            programs[b] = cA;
        }

        public static void Partner(this char[] programs, char a, char b) =>
            programs.Exchange(Array.IndexOf(programs, a), Array.IndexOf(programs,b));
    }
}
