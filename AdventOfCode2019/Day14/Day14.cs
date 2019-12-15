using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public class Chemical
    {
        public Chemical(string input)
        {
            var parts = input.Split(' ');
            Amount = parts[0].ToInt();
            Name = parts[1];
        }

        public String Name { get; set; }
        public decimal Amount { get; set; }

        public override string ToString() =>
            $"{Amount} {Name}";
    }

    public class ChemicalOutput : Chemical
    {
        public ChemicalOutput(string input) : base(input)
        {
        }
        public bool Need { get; set; }
        public decimal OnHand { get; set; }
        public override string ToString() =>
            $"{OnHand}/{Amount} {Name} N:{Need}";
    }

    public class Conversion
    {
        string _line;

        public Conversion(string line)
        {
            _line = line;
            var io = line.Split(" => ");
            Output = new ChemicalOutput(io[1]);

            var input = io[0].Split(", ");
            Inputs.AddRange(input.Select(i => new Chemical(i)));
        }

        public ChemicalOutput Output { get; set; }
        public List<Chemical> Inputs { get; } = new List<Chemical>();
        public override string ToString() =>
            $"{_line}, on hand {Output.OnHand} N:{Output.Need}";
    }

    public static class Day14
    {
        static Dictionary<string, Conversion> conversions;

        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            conversions = new Dictionary<string, Conversion>();
            foreach (var conversion in lines.Select(l => new Conversion(l)))
            {
                conversions.Add(conversion.Output.Name, conversion);
            }

            int ore = 0;

            while (conversions["FUEL"].Output.OnHand == 0)
            {
                CalculateNeedsFor("FUEL");

                foreach (var need in conversions.Values.Where(c => c.Output.Need && c.Inputs.Any(i => i.Name == "ORE")))
                {
                    int oreUsed = (int)need.Inputs.Where(c => c.Name == "ORE").Select(c => c.Amount).First();
                    need.Output.OnHand += need.Output.Amount;
                    need.Output.Need = false;
                    ore += oreUsed;
                }

                foreach (var conv in conversions.Values.Where(c => c.Output.Need))
                {
                    if (conv.Inputs.Any(i => conversions[i.Name].Output.OnHand < i.Amount))
                    {
                        continue;
                    }
                    foreach (var chem in conv.Inputs)
                    {
                        conversions[chem.Name].Output.OnHand -= chem.Amount;
                    }
                    conv.Output.OnHand += conv.Output.Amount;
                    conv.Output.Need = false;
                }
            }
            return ore;
        }

        static void CalculateNeedsFor(string name)
        {
            var conversion = conversions[name];
            conversion.Output.Need = true;
            foreach (var input in conversion.Inputs)
            {
                if (input.Name == "ORE")
                {
                    conversion.Output.Need = true;
                }
                else if (conversions[input.Name].Output.OnHand < input.Amount)
                {
                    CalculateNeedsFor(input.Name);
                }
            }
        }

        public static long PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            conversions = new Dictionary<string, Conversion>();
            foreach (var conversion in lines.Select(l => new Conversion(l)))
            {
                conversions.Add(conversion.Output.Name, conversion);
            }

            decimal ore = CalculateRequirementsFor("FUEL");
            return (long)(1000000000000m / ore);
        }

        static decimal CalculateRequirementsFor(string name)
        {
            var conversion = conversions[name];
            decimal requirements = 0;
            foreach (var input in conversion.Inputs)
            {
                if (input.Name == "ORE")
                {
                    return input.Amount / conversion.Output.Amount;
                }
                else
                {
                    requirements += input.Amount * CalculateRequirementsFor(input.Name);
                }
            }
            return requirements / conversion.Output.Amount;
        }
    }
}
