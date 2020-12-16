using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public class Rule
    {
        public string Name { get; set; }
        public int LowOne { get; set; }
        public int HighOne { get; set; }
        public int LowTwo { get; set; }
        public int HighTwo { get; set; }

        public Rule(string line)
        {
            string[] parts = line.Split(": ");
            Name = parts[0];

            string[] ranges = parts[1].Split(" or ");
            string[] range = ranges[0].Split("-");
            LowOne = range[0].ToInt();
            HighOne = range[1].ToInt();

            range = ranges[1].Split("-");
            LowTwo = range[0].ToInt();
            HighTwo = range[1].ToInt();
        }

        public bool Valid(int n) =>
            (n >= LowOne && n <= HighOne) || (n >= LowTwo && n <= HighTwo);

        public override bool Equals(object obj)
        {
            var other = obj as Rule;
            return other != null ? other.Name == Name : false;
        }

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => Name;
    }
}
