using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day18
    {
        public static long PartOne(string filename) =>
            filename.ReadAllLines()
                    .Select(l => EvaluatePartOne(l))
                    .Sum();

        public static long PartTwo(string filename) =>
            filename.ReadAllLines()
                    .Select(l => EvaluatePartTwo(l))
                    .Sum();

        public static long EvaluatePartOne(string equation)
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

        public static long EvaluatePartTwo(string equation)
        {
            while (ContainsParens(equation))
            {
                (int start, int end) = FindInnermostParens(equation);
                string inner = GetInnerEquation(equation, start, end);
                long result = EvaluateWithoutParensAndPrecedence(inner);
                equation = SubsituteInnerWithResult(equation, result, start, end);
            }
            return EvaluateWithoutParensAndPrecedence(equation);
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

        public static long EvaluateWithoutParensAndPrecedence(string equation)
        {
            var parts = equation.Split(' ');
            long last = parts[0].ToLong();
            List<long> multiplication = new List<long>();
            for(int i = 1; i < parts.Length; i += 2)
            {
                if (parts[i] == "*")
                {
                    multiplication.Add(last);
                    last = parts[i + 1].ToLong();
                }
                else if (parts[i] == "+")
                {
                    last += parts[i + 1].ToLong();
                }
            }
            multiplication.Add(last);
            return multiplication.Aggregate(1L, (x, y) => x * y);
        }
    }
}
