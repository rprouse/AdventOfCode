using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day18
    {
        public static long PartOne(string filename) =>
            filename.ReadAllLines()
                    .Select(l => Evaluate(l))
                    .Sum();

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }

        public static long Evaluate(string equation)
        {
            while(ContainsParens(equation))
            {
                (int start, int end) = FindInnermostParens(equation);
                string inner = GetInnerEquation(equation, start, end);
                long result = EvaluateWithoutParens(inner);
                equation = SubsituteInnerWithResult(equation, result, start, end);
            }
            return EvaluateWithoutParens(equation);
        }

        public static (int start, int end) FindInnermostParens(string equation)
        {
            int start = 0;
            int end = 1;
            int nextStart = 0;

            while (nextStart != -1 && nextStart < end)
            {
                start = equation.IndexOf('(', start + 1);
                end = equation.IndexOf(')', start + 1);
                nextStart = equation.IndexOf('(', start + 1);
            }
            return (start, end);
        }

        public static string GetInnerEquation(string equation, int start, int end) =>
            equation[(start + 1)..(end)];

        public static bool ContainsParens(string equation) =>
            equation.Any(c => c == '(');

        public static long EvaluateWithoutParens(string equation)
        {
            var parts = equation.Split(' ');
            long val = parts[0].ToLong();
            for(int i = 1; i < parts.Length; i += 2)
            {
                if (parts[i] == "+") val += parts[i + 1].ToLong();
                else if (parts[i] == "*") val *= parts[i + 1].ToLong();
                else throw new InvalidOperationException($"Unexpected operator {parts[i]}");
            }
            return val;
        }

        public static string SubsituteInnerWithResult(string equation, long result, int start, int end) =>
            equation[0..start] + result.ToString() + equation[(end+1)..];
    }
}
