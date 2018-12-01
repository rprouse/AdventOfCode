using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public class Day10
    {
        Regex _valRegex = new Regex(@"value (\d+) goes to bot (\d+)", RegexOptions.Compiled | RegexOptions.Multiline);
        Regex _botRegex = new Regex(@"bot (\d+) gives low to (bot|output) (\d+) and high to (bot|output) (\d+)", RegexOptions.Compiled);

        Dictionary<int, int> _output = new Dictionary<int, int>();
        Dictionary<int, Bot> _bots = new Dictionary<int, Bot>();

        public int ParseFileOne(string filename, int high, int low)
        {
            string file = filename.ReadAll();
            var valMatch = _valRegex.Matches(file);
            foreach(Match match in valMatch)
            {
                ParseValue(match);
            }
            var found = BotWithChips(high, low);
            if (found != -1)
                return found;

            string[] lines = filename.ReadAllLines();
            while(true)
            {
                var bots = BotsWithTwoChips();
                if (bots.Count == 0)
                    throw new ArgumentException("No bots found with two chips");
                //if (bots.Count > 1)
                //    throw new ArgumentException($"{bots.Count} bots found with two chips");
                foreach (var bot in bots)
                {
                    string line = lines.Where(l => l.StartsWith($"bot {bot.Key} gives")).FirstOrDefault();
                    if (line == null)
                        throw new ArgumentException($"Failed to find instructions for bot {bot.Key}");

                    var match = _botRegex.Match(line);
                    ParseBot(match);
                    found = BotWithChips(high, low);
                    if (found != -1)
                        return found;
                }
            }
        }

        public int ParseFileTwo(string filename)
        {
            string file = filename.ReadAll();
            var valMatch = _valRegex.Matches(file);
            foreach (Match match in valMatch)
            {
                ParseValue(match);
            }

            string[] lines = filename.ReadAllLines();
            while (true)
            {
                var bots = BotsWithTwoChips();
                if (bots.Count == 0)
                    break;

                foreach (var bot in bots)
                {
                    string line = lines.Where(l => l.StartsWith($"bot {bot.Key} gives")).FirstOrDefault();
                    if (line == null)
                        throw new ArgumentException($"Failed to find instructions for bot {bot.Key}");

                    var match = _botRegex.Match(line);
                    ParseBot(match);
                }
            }
            return _output[0] * _output[1] * _output[2];
        }

        IList<KeyValuePair<int, Bot>> BotsWithTwoChips() =>
            _bots.Where(p => p.Value.HasTwoChips).ToList();

        void ParseValue(Match match)
        {
            int.TryParse(match.Groups[1].Value, out int val);
            int.TryParse(match.Groups[2].Value, out int bot);
            GetBot(bot).Give(val);
        }

        void ParseBot(Match match)
        {
            int.TryParse(match.Groups[1].Value, out int bot);
            bool lowToBot = match.Groups[2].Value == "bot";
            int.TryParse(match.Groups[3].Value, out int lowTo);
            bool highToBot = match.Groups[4].Value == "bot";
            int.TryParse(match.Groups[5].Value, out int hightTo);
            Bot from = GetBot(bot);
            (int low, int high) = from.Take();
            if (low != -1)
            {
                if (lowToBot)
                    GetBot(lowTo).Give(low);
                else
                    _output[lowTo] = low;
            }

            if (high != -1)
            {
                if (highToBot)
                    GetBot(hightTo).Give(high);
                else
                    _output[hightTo] = high;
            }
        }

        Bot GetBot(int n)
        {
            if (!_bots.ContainsKey(n))
                _bots.Add(n, new Bot());
            return _bots[n];
        }

        int BotWithChips(int high, int low)
        {
            foreach(int key in _bots.Keys)
            {
                Bot bot = _bots[key];
                if (bot.High == high && bot.Low == low)
                    return key;
            }
            return -1;
        }

        public static int PartOne(string filename, int high, int low)
        {
            var day10 = new Day10();
            return day10.ParseFileOne(filename, high, low);
        }

        public static int PartTwo(string filename)
        {
            var day10 = new Day10();
            return day10.ParseFileTwo(filename);
        }

        class Bot
        {
            int? _one;
            int? _two;

            public int? High
            {
                get
                {
                    if (_one.HasValue && _two.HasValue)
                        return _one.Value > _two.Value ? _one : _two;
                    else if (_one.HasValue)
                        return _one;
                    else
                        return _two;
                }
            }

            public int? Low
            {
                get
                {
                    if (_one.HasValue && _two.HasValue)
                        return _one.Value < _two.Value ? _one : _two;
                    else if (_one.HasValue)
                        return _one;
                    else
                        return _two;
                }
            }

            public bool HasTwoChips => _one.HasValue && _two.HasValue;

            public void Give(int val)
            {
                if (!_one.HasValue)
                    _one = val;
                else if (!_two.HasValue)
                    _two = val;
                else
                    throw new ArgumentException("Attempting to give bot a third chip");
            }

            public (int, int) Take()
            {
                int low = -1;
                int high = -1;
                if (_one.HasValue && _two.HasValue)
                {
                    if (_one.Value < _two.Value)
                    {
                        low = _one.Value;
                        high = _two.Value;
                    }
                    else
                    {
                        high = _one.Value;
                        low = _two.Value;
                    }
                    _one = null;
                    _two = null;
                    return (low, high);
                }
                throw new ArgumentException("Attempting to take from bot without two values");
            }

            public int TakeLow()
            {
                int ret = -1;
                if (_one.HasValue && _two.HasValue)
                {
                    if (_one.Value > _two.Value)
                    {
                        ret = _two.Value;
                        _two = null;
                    }
                    else
                    {
                        ret = _one.Value;
                        _one = null;
                    }
                }
                else if (_one.HasValue)
                {
                    ret = _one.Value;
                    _one = null;
                }
                else if (_two.HasValue)
                {
                    ret = _two.Value;
                    _two = null;
                }
                return ret;
            }

            public override string ToString()
            {
                return $"({_one},{_two})";
            }

            public override bool Equals(object obj)
            {
                var other = obj as Bot;
                if (other == null)
                    return false;

                return _one == other._one && _two == other._two;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = 17;
                    hashCode = (hashCode * 23) + _one.GetHashCode();
                    return (hashCode * 23) + _two.GetHashCode();
                }
            }
        }
    }
}
