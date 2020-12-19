using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day19
    {
        public static int PartOne(string filename)
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
            foreach(var rule in rules.Values)
            {
                rule.Attach(rules);
            }
            int m = 0;
            foreach(string message in messages)
            {
                if (rules[0].Matches(message))
                    m++;
            }
            return m;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
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

        internal (bool, string) MatchesRules(string message)
        {
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

        public override string ToString() => _rule;
    }
}
