﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2017
{
    public static class Day9
    {
        public static IEnumerable<string> ReadSomething(string filename) =>
            LineReader.ReadLines(filename);

        public static int ScoreGroups(this string str)
        {
            var clean = str.StripGarbage();
            int sum = 0;
            int depth = 0;
            foreach(char c in clean)
            {
                switch(c)
                {
                    case '{':
                        depth++;
                        sum += depth;
                        break;
                    case '}':
                        depth--;
                        break;
                }
            }
            return sum;
        }

        public static string StripGarbage(this string str)
        {
            var sb = new StringBuilder();
            bool garbage = false;
            bool skip = false;
            foreach(char c in str)
            {
                if(skip)
                {
                    skip = false;
                    continue;
                }
                switch (c)
                {
                    case '<':
                        garbage = true;
                        continue;
                    case '!':
                        skip = true;
                        continue;
                    case '>':
                        garbage = false;
                        continue;
                }
                if(!garbage)
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
