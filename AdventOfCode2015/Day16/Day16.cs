using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015;

public static class Day16
{
    public class MFCSAM
    {
        public MFCSAM(string line)
        {
            var p1 = line.Split(": ", 2);
            Number = p1[0].Substring(4).ToInt();
            foreach(string part in p1[1].Split(", ")) 
            {
                var p2 = part.Split(": ");
                switch(p2[0])
                {
                    case "children":
                        Children = p2[1].ToInt();
                        break;
                    case "cats":
                        Cats = p2[1].ToInt();
                        break;
                    case "samoyeds":
                        Samoyeds = p2[1].ToInt();
                        break;
                    case "pomeranians":
                        Pomeranians = p2[1].ToInt();
                        break;
                    case "akitas":
                        Akitas = p2[1].ToInt();
                        break;
                    case "vizslas":
                        Vizslas = p2[1].ToInt();
                        break;
                    case "goldfish":
                        Goldfish = p2[1].ToInt();
                        break;
                    case "trees":
                        Trees = p2[1].ToInt();
                        break;
                    case "cars":
                        Cars = p2[1].ToInt();
                        break;
                    case "perfumes":
                        Perfumes = p2[1].ToInt();
                        break;
                }
            }
        }

        public bool Matches()
        {
            if (Children.HasValue && Children != 3) return false;
            if (Cats.HasValue && Cats != 7) return false;
            if (Samoyeds.HasValue && Samoyeds != 2) return false;
            if (Pomeranians.HasValue && Pomeranians != 3) return false;
            if (Akitas.HasValue && Akitas != 0) return false;
            if (Vizslas.HasValue && Vizslas != 0) return false;
            if (Goldfish.HasValue && Goldfish != 5) return false;
            if (Trees.HasValue && Trees != 3) return false;
            if (Cars.HasValue && Cars != 2) return false;
            if (Perfumes.HasValue && Perfumes != 1) return false;
            return true;
        }

        public int Number { get; }
        public int? Children { get; }
        public int? Cats { get; }
        public int? Samoyeds { get; }
        public int? Pomeranians { get; }
        public int? Akitas { get; }
        public int? Vizslas { get; }
        public int? Goldfish { get; }
        public int? Trees { get; }
        public int? Cars { get; }
        public int? Perfumes { get; }
    }

    public static int PartOne(string filename) =>
        filename.ReadAllLines()
            .Select(l => new MFCSAM(l))
            .Where(a => a.Matches())
            .First()
            .Number;

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
