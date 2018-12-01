using System;
using System.Collections.Generic;
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
            ReadValues(filename);
            var found = BotWithChips(high, low);
            if (found != -1)
                return found;

            string[] lines = filename.ReadAllLines();
            while(true)
            {
                var bots = BotsWithTwoChips();
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
            ReadValues(filename);

            string[] lines = filename.ReadAllLines();
            var bots = BotsWithTwoChips();
            while (bots.Count > 0)
            {
                foreach (var bot in bots)
                {
                    string line = lines.Where(l => l.StartsWith($"bot {bot.Key} gives")).FirstOrDefault();
                    if (line == null)
                        throw new ArgumentException($"Failed to find instructions for bot {bot.Key}");

                    var match = _botRegex.Match(line);
                    ParseBot(match);
                }
                bots = BotsWithTwoChips();
            }
            return _output[0] * _output[1] * _output[2];
        }

        private void ReadValues(string filename)
        {
            string file = filename.ReadAll();
            var valMatch = _valRegex.Matches(file);
            foreach (Match match in valMatch)
            {
                ParseValue(match);
            }
        }

        IList<KeyValuePair<int, Bot>> BotsWithTwoChips() =>
            _bots.Where(p => p.Value.HasTwoChips).ToList();

        void ParseValue(Match match)
        {
            int val = match.GetInt(1);
            int bot = match.GetInt(2);
            GetBot(bot).Give(val);
        }

        void ParseBot(Match match)
        {
            int bot = match.GetInt(1);
            bool lowToBot = match.Groups[2].Value == "bot";
            int lowTo = match.GetInt(3);
            bool highToBot = match.Groups[4].Value == "bot";
            int highTo = match.GetInt(5);

            Bot from = GetBot(bot);
            (int low, int high) = from.Take();
            if (lowToBot)
                GetBot(lowTo).Give(low);
            else
                _output[lowTo] = low;

            if (highToBot)
                GetBot(highTo).Give(high);
            else
                _output[highTo] = high;
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
                if (bot.HasChips(high, low))
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

            public bool HasChips(int high, int low) =>
                (_one == high && _two == low) || (_one == low && _two == high);

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
                if (!_one.HasValue && !_two.HasValue)
                    throw new ArgumentException("Attempting to take from bot without two values");

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

            public override string ToString() =>
                $"({_one},{_two})";
        }
    }
}
