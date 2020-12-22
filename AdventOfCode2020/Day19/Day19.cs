using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day19
    {
        public static int PartOne(string filename)
        {
            (var rules, var messages) = ParseRegex(filename);
            var regex = new Regex($"^{rules[0].GetRegex()}$", RegexOptions.Compiled | RegexOptions.Singleline);

            int m = 0;
            foreach(string message in messages)
            {
                if(regex.Match(message).Success)
                    m++;
            }
            return m;
        }

        private static (Dictionary<int, Day19Regex> rules, List<string> messages) ParseRegex(string filename)
        {
            string[] lines = filename.ReadAllLines();

            Dictionary<int, Day19Regex> rules = new Dictionary<int, Day19Regex>();
            List<string> messages = new List<string>();
            foreach (string line in lines)
            {
                if (line[0] == 'a' || line[0] == 'b')
                    messages.Add(line);
                else
                {
                    var rule = new Day19Regex(line);
                    rules.Add(rule.Number, rule);
                }
            }
            foreach (var rule in rules.Values)
            {
                rule.Attach(rules);
            }
            do
            {
                foreach (var rule in rules.Values)
                    rule.GetRegex();

            } while (rules.Values.Any(r => r.GetRegex() == null)) ;
            return (rules, messages);
        }

        private static (Dictionary<int, Day19Rule> rules, List<string> messages) Parse(string filename)
        {
            string[] lines = filename.ReadAllLines();

            Dictionary<int, Day19Rule> rules = new Dictionary<int, Day19Rule>();
            List<string> messages = new List<string>();
            foreach (string line in lines)
            {
                if (line[0] == 'a' || line[0] == 'b')
                    messages.Add(line);
                else
                {
                    var rule = new Day19Rule(line);
                    rules.Add(rule.Number, rule);
                }
            }
            foreach (var rule in rules.Values)
            {
                rule.Attach(rules);
            }
            return (rules, messages);
        }

        public static int PartTwo(string filename)
        {
            (var rules, var messages) = ParseRegex(filename);

            string r31 = rules[31].GetRegex();
            string r42 = rules[42].GetRegex();

            var regexes = new Regex[]
            {
                new Regex($"^{r42}{r42}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r42}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),

                new Regex($"^{r42}{r42}{r42}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r42}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r42}{r42}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),

                new Regex($"^{r42}{r42}{r42}{r42}{r31}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r31}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r42}{r31}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r42}{r42}{r31}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r42}{r42}{r42}{r31}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),

                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r31}{r31}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r42}{r31}{r31}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r42}{r42}{r31}{r31}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r42}{r42}{r42}{r31}{r31}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
                new Regex($"^{r42}{r42}{r42}{r42}{r42}{r42}{r42}{r42}{r42}{r31}{r31}{r31}{r31}$", RegexOptions.Compiled | RegexOptions.Singleline),
            };

            int m = 0;
            foreach (string message in messages)
            {
                if (regexes.Any(r => r.Match(message).Success))
                    m++;
            }
            return m;
        }
    }

    public class Day19Regex
    {
        public int Number { get; }

        string _regex;
        readonly string _rule;
        readonly string _ruleA;
        readonly string _ruleB;

        Day19Regex[] _rulesA;
        Day19Regex[] _rulesB;

        public Day19Regex(string rule)
        {
            _rule = rule;
            var parts = rule.Split(": ");
            Number = parts[0].ToInt();
            if (parts[1][0] == '"')
            {
                _regex = $"(?:{parts[1][1]})";
            }
            else
            {
                var subRules = parts[1].Split(" | ");
                _ruleA = subRules[0];
                _ruleB = subRules.Length == 2 ? subRules[1] : null;
            }
        }

        public void Attach(Dictionary<int, Day19Regex> rules)
        {
            if (_regex != null)
                return;

            _rulesA = _ruleA.Split(' ').Select(s => rules[s.ToInt()]).ToArray();

            if (_ruleB == null) return;

            _rulesB = _ruleB.Split(' ').Select(s => rules[s.ToInt()]).ToArray();
        }

        public string GetRegex()
        {
            if (_regex != null)
                return _regex;

            if (_rulesA.Any(r => r.GetRegex() == null))
                return null;

            if (_rulesB != null && _rulesB.Any(r => r.GetRegex() == null))
                return null;

            if(_rulesB != null)
            {
                _regex = $"(?:(?:{string.Join("", _rulesA.Select(r => r.GetRegex()))})|(?:{string.Join("", _rulesB.Select(r => r.GetRegex()))}))";
            }
            else
            {
                _regex = $"(?:{string.Join("", _rulesA.Select(r => r.GetRegex()))})";
            }
            return _regex;
        }

        public override string ToString() => $"{Number}: {_regex}";
    }
}
