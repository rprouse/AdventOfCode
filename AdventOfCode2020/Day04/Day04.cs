using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day04
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLinesIncludingBlank();
            var passports = ParseFile(lines);
            return passports.Count(p => DoesPassportHaveRequiredFields(p));
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLinesIncludingBlank();
            var passports = ParseFile(lines);
            return passports.Count(p => IsPassportValid(p));
        }

        static bool DoesPassportHaveRequiredFields(IDictionary<string, string> pass) =>
            pass.ContainsKey("byr") &&
            pass.ContainsKey("iyr") &&
            pass.ContainsKey("eyr") &&
            pass.ContainsKey("hgt") &&
            pass.ContainsKey("hcl") &&
            pass.ContainsKey("ecl") &&
            pass.ContainsKey("pid");

        // byr(Birth Year) - four digits; at least 1920 and at most 2002.
        // iyr(Issue Year) - four digits; at least 2010 and at most 2020.
        // eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
        // hgt(Height) - a number followed by either cm or in:
        //   If cm, the number must be at least 150 and at most 193.
        //   If in, the number must be at least 59 and at most 76.
        // hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        // ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        // pid(Passport ID) - a nine-digit number, including leading zeroes.
        // cid(Country ID) - ignored, missing or not.
        static bool IsPassportValid(IDictionary<string, string> pass)
        {
            bool byr = false;   // (Birth Year)
            bool iyr = false;   // (Issue Year)
            bool eyr = false;   // (Expiration Year)
            bool hgt = false;   // (Height)
            bool hcl = false;   // (Hair Color)
            bool ecl = false;   // (Eye Color)
            bool pid = false;   // (Passport ID)
            bool cid = false;   // (Country ID)
            foreach (var pair in pass)
            {
                switch (pair.Key)
                {
                    case "byr":
                    {
                        int year = pair.Value.ToInt();
                        byr = year >= 1920 && year <= 2002;
                        break;
                    }
                    case "iyr":
                    {
                        int year = pair.Value.ToInt();
                        iyr = year >= 2010 && year <= 2020;
                        break;
                    }
                    case "eyr":
                    {
                        int year = pair.Value.ToInt();
                        eyr = year >= 2020 && year <= 2030;
                        break;
                    }
                    case "hgt":
                    {
                        if(pair.Value.EndsWith("in"))
                        {
                            int h = pair.Value.Substring(0, pair.Value.Length - 2).ToInt();
                                hgt = h >= 59 && h <= 76;
                            }
                        else if(pair.Value.EndsWith("cm"))
                        {
                            int h = pair.Value.Substring(0, pair.Value.Length - 2).ToInt();
                                hgt = h >= 150 && h <= 193;
                        }
                        break;
                    }
                    case "hcl":
                    {
                        var val = pair.Value;
                        hcl = val.StartsWith("#") && val.Length == 7 && val.All(c => c == '#' || (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f'));
                        break;
                    }
                    case "ecl":
                    {
                        var val = pair.Value;
                        ecl = val == "amb" || val == "blu" || val == "brn" || val == "gry" || val == "grn" || val == "hzl" || val == "oth";
                        break;
                    }
                    case "pid":
                        pid = pair.Value.Length == 9 && pair.Value.All(c => c >= '0' && c <= '9');
                        break;
                    case "cid":
                        cid = true;
                        break;
                }
            }
            return byr && iyr && eyr && hgt && hcl && ecl && pid;
        }

        static IEnumerable<IDictionary<string, string>> ParseFile(string[] lines)
        {
            var dict = new Dictionary<string, string>();
            foreach(var line in lines)
            {
                if(string.IsNullOrEmpty(line))
                {
                    yield return dict;
                    dict = new Dictionary<string, string>();
                    continue;
                }
                string[] pairs = line.Split(' ');
                foreach(var pair in pairs)
                {
                    string[] parts = pair.Split(':', 2);
                    dict.Add(parts[0], parts[1]);
                }
            }
            yield return dict;
        }
    }
}
