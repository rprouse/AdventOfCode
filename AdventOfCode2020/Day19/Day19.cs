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
            (var rules, var messages) = Parse(filename);
            int m = 0;
            foreach (string message in messages)
            {
                if (rules[0].MatchesLooping(message))
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

    public class Day19Rule
    {
        public int Number { get; }

        readonly char _char = ' ';
        readonly string _rule;
        readonly string _ruleA;
        readonly string _ruleB;

        Day19Rule[] _rulesA;
        Day19Rule[] _rulesB;

        public Day19Rule(string rule)
        {
            _rule = rule;
            var parts = rule.Split(": ");
            Number = parts[0].ToInt();
            if (parts[1][0] == '"')
            {
                _char = parts[1][1];
            }
            else
            {
                var subRules = parts[1].Split(" | ");
                _ruleA = subRules[0];
                _ruleB = subRules.Length == 2 ? subRules[1] : null;
            }
        }

        public void Attach(Dictionary<int, Day19Rule> rules)
        {
            if (_char == 'a' || _char == 'b')
                return;

            _rulesA = _ruleA.Split(' ').Select(s => rules[s.ToInt()]).ToArray();

            if (_ruleB == null) return;

            _rulesB = _ruleB.Split(' ').Select(s => rules[s.ToInt()]).ToArray();
        }

        public bool Matches(string message)
        {
            (bool matches, string stripped) = MatchesRules(message);
            return matches && stripped.Length == 0;
        }

        public bool MatchesLooping(string message)
        {
            // Rule A for the entry rule 0 is 8: 42 and 11: 42 31, so grab them from 11
            var rule42 = _rulesA[1]._rulesA[0];
            var rule31 = _rulesA[1]._rulesA[1];

            string stripped8 = message;
            string stripped11;
            bool matched8;
            bool matched11 = false;

            (matched8, stripped8) = rule42.MatchesRules(stripped8);
            while(matched8)
            {
                List<Day19Rule> rules = new List<Day19Rule> { rule42, rule31 };
                while (true)
                {
                    stripped11 = stripped8;
                    foreach (var rule in rules)
                    {
                        (matched11, stripped11) = rule.MatchesRules(stripped11);
                        if (!matched11) break;
                    }
                    if (matched11 && stripped11.Length == 0) return true;
                    rules.Prepend(rule42);
                    rules.Add(rule31);
                    if (rules.Count >= message.Length) break;
                }
                string stripped8B;
                bool matched8B;
                (matched8B, stripped8B) = rule42.MatchesRules(stripped8);
                (matched8, stripped8) = (matched8B, stripped8B);
            }
            return false;

            //if (Number == 8)
            //{
            //    (matched1, stripped1) = _rulesA[0].MatchesRules(stripped1);
            //    while (matched1)
            //    {
            //        (matched2, stripped2) = _rulesA[0].MatchesRules(stripped1);
            //        if (!matched2)
            //            return (matched1, stripped1);
            //        (matched1, stripped1) = (matched2, stripped2);
            //    }
            //    return (matched1, stripped1);
            //}
            //else
            //{
            //    List<Day19Rule> rules = new List<Day19Rule>(_rulesA);

            //    while (true)
            //    {
            //        stripped2 = message;
            //        foreach (var rule in rules)
            //        {
            //            (matched2, stripped2) = rule.MatchesRules(stripped2);
            //            if (!matched2) break;
            //        }
            //        if (matched2) return (matched2, stripped2);
            //        rules.Prepend(_rulesA[0]);
            //        rules.Add(_rulesA[1]);
            //        if (rules.Count >= message.Length) return (false, message);
            //        //(matched1, stripped1) = (matched2, stripped2);
            //    }
            //}
        }

        internal (bool, string) MatchesRules(string message)
        {
            if (message.Length == 0) 
                return (false, message);

            if (_char != ' ')
            {
                if (message[0] == _char)
                    return (true, message[1..]);
                else
                    return (false, message);
            }

            (bool matchesA, string stripped) = MatchesRulesA(message);
            if (matchesA) return (true, stripped);

            return MatchesRulesB(message);
        }

        internal (bool, string) MatchesRulesA(string message)
        {
            string stripped = message;

            foreach (var rule in _rulesA)
            {
                bool matches;
                (matches, stripped) = rule.MatchesRules(stripped);
                if (!matches) return (false, message);
            }
            return (true, stripped);
        }

        internal (bool, string) MatchesRulesB(string message)
        {
            if (_ruleB == null) return (false, message);

            string stripped = message;
            foreach (var rule in _rulesB)
            {
                bool matches;
                (matches, stripped) = rule.MatchesRules(stripped);
                if (!matches) return (false, message);
            }
            return (true, stripped);
        }

        internal (bool, string) LoopingMatch(string message)
        {
            string stripped1 = message;
            string stripped2 = message;
            bool matched1 = false;
            bool matched2 = false;
            if (Number == 8)
            {
                (matched1, stripped1) = _rulesA[0].MatchesRules(stripped1);
                while(matched1)
                {
                    (matched2, stripped2) = _rulesA[0].MatchesRules(stripped1);
                    if (!matched2)
                        return (matched1, stripped1);
                    (matched1, stripped1) = (matched2, stripped2);
                }
                return (matched1, stripped1);
            }
            else
            {
                List<Day19Rule> rules = new List<Day19Rule>(_rulesA);

                while(true)
                {
                    stripped2 = message;
                    foreach (var rule in rules)
                    {
                        (matched2, stripped2) = rule.MatchesRules(stripped2);
                        if (!matched2) break;
                    }
                    if (matched2) return (matched2, stripped2);
                    rules.Prepend(_rulesA[0]);
                    rules.Add(_rulesA[1]);
                    if (rules.Count >= message.Length) return (false, message);
                    //(matched1, stripped1) = (matched2, stripped2);
                }
            }
        }

        public override string ToString() => _rule;
    }
}
