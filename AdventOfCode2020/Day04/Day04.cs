using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day04
    {
        public static int PartOne(string filename) =>
            ParseFile(filename.ReadAllLinesIncludingBlank())
                .Count(p => DoesPassportHaveRequiredFields(p));

        public static int PartTwo(string filename) =>
            ParseFile(filename.ReadAllLinesIncludingBlank())
                .Count(p => IsPassportValid(p));

        static bool DoesPassportHaveRequiredFields(IDictionary<string, string> pass) =>
            pass.ContainsKey("byr") &&
            pass.ContainsKey("iyr") &&
            pass.ContainsKey("eyr") &&
            pass.ContainsKey("hgt") &&
            pass.ContainsKey("hcl") &&
            pass.ContainsKey("ecl") &&
            pass.ContainsKey("pid");

        static bool IsPassportValid(IDictionary<string, string> pass) =>
            IsByrValid(pass) && 
            IsIyrValid(pass) && 
            IsEyrValid(pass) && 
            IsHgtValid(pass) && 
            IsHclValid(pass) && 
            IsEclValid(pass) && 
            IsPidValid(pass);
        
        // byr(Birth Year) - four digits; at least 1920 and at most 2002.
        static internal bool IsByrValid(IDictionary<string, string> pass) =>
            pass.ContainsKey("byr") && IsValidYear(pass["byr"], 1920, 2002);
        
        // iyr(Issue Year) - four digits; at least 2010 and at most 2020.
        static internal bool IsIyrValid(IDictionary<string, string> pass) =>
            pass.ContainsKey("iyr") && IsValidYear(pass["iyr"], 2010, 2020);

        // eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
        static internal bool IsEyrValid(IDictionary<string, string> pass) =>
            pass.ContainsKey("eyr") && IsValidYear(pass["eyr"], 2020, 2030);

        // hgt(Height) - a number followed by either cm or in:
        //   If cm, the number must be at least 150 and at most 193.
        //   If in, the number must be at least 59 and at most 76.
        static internal bool IsHgtValid(IDictionary<string, string> pass)
        {
            if (!pass.ContainsKey("hgt")) return false;

            string hgt = pass["hgt"];
            int h = hgt[..^2].ToInt();
            return hgt[^2..] switch
            {
                "in" => h is >= 59 and <= 76,
                "cm" => h is >= 150 and <= 193,
                _    => false 
            };
        }

        // hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        static internal bool IsHclValid(IDictionary<string, string> pass)
        {
            if (!pass.ContainsKey("hcl")) return false;

            var hcl = pass["hcl"];
            return hcl.StartsWith("#") && 
                   hcl.Length == 7 && 
                   int.TryParse(hcl[1..], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int _);
        }

        // ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        static internal bool IsEclValid(IDictionary<string, string> pass)
        {
            if (!pass.ContainsKey("ecl")) return false;

            var val = pass["ecl"];
            return val == "amb" || val == "blu" || val == "brn" || val == "gry" || val == "grn" || val == "hzl" || val == "oth";            
        }

        // pid(Passport ID) - a nine-digit number, including leading zeroes.
        static internal bool IsPidValid(IDictionary<string, string> pass)
        {
            if (!pass.ContainsKey("pid")) return false;

            var pid = pass["pid"];
            return pid.Length == 9 && pid.All(c => char.IsDigit(c));
        }

        static internal bool IsValidYear(string value, int min, int max)
        {
            int year = value.ToInt();
            return year >= min && year <= max;
        }

        static IEnumerable<IDictionary<string, string>> ParseFile(string[] lines)
        {
            var dict = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    yield return dict;
                    dict = new Dictionary<string, string>();
                    continue;
                }
                string[] pairs = line.Split(' ');
                foreach (var pair in pairs)
                {
                    string[] parts = pair.Split(':', 2);
                    dict.Add(parts[0], parts[1]);
                }
            }
            yield return dict;
        }
    }
}
