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
            return passports.Count(p => IsPassportValid(p));
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLinesIncludingBlank();
            return 0;
        }

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
            foreach(string key in pass.Keys)
            {
                switch(key)
                {
                    case "byr":
                        byr = true;
                        break;
                    case "iyr":
                        iyr = true;
                        break;
                    case "eyr":
                        eyr = true;
                        break;
                    case "hgt":
                        hgt = true;
                        break;
                    case "hcl":
                        hcl = true;
                        break;
                    case "ecl":
                        ecl = true;
                        break;
                    case "pid":
                        pid = true;
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
