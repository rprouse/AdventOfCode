using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day07
    {
        static Dictionary<string, ushort> circuit;

        private static (bool, ushort) GetValue(string val)
        {
            if(ushort.TryParse(val, out ushort o1))
                return (true, o1);
            else if (circuit.ContainsKey(val))
                return (true, circuit[val]);
            return (false, 0);
        }

        public static ushort PartOne(string filename, string val)
        {
            List<string> lines = filename.ReadAllLines().ToList();
            circuit = new Dictionary<string, ushort>();
            while(lines.Count > 0)
            {
                var notReady = new List<string>();
                foreach (var line in lines)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length == 3)
                    {
                        (bool found, ushort o1) = GetValue(parts[0]);
                        if(found)
                            circuit[parts[2]] = o1;
                        else
                            notReady.Add(line);
                    }
                    else if (parts.Length == 4)
                    {
                        // NOT
                        if (circuit.ContainsKey(parts[1]))
                            circuit[parts[3]] = (ushort)(~circuit[parts[1]]);
                        else
                            notReady.Add(line);
                    }
                    else if (parts.Length == 5)
                    {
                        (bool found1, ushort o1) = GetValue(parts[0]);
                        (bool found2, ushort o2) = GetValue(parts[2]);
                        if (found1 && found2)
                        {
                            switch(parts[1])
                            {
                                case "AND":
                                    circuit[parts[4]] = (ushort)(o1 & o2);
                                    break;
                                case "OR":
                                    circuit[parts[4]] = (ushort)(o1 | o2);
                                    break;
                                case "LSHIFT":
                                    circuit[parts[4]] = (ushort)((o1 << o2) & 0x0000FFFF);
                                    break;
                                case "RSHIFT":
                                    circuit[parts[4]] = (ushort)(o1 >> o2);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                            notReady.Add(line);
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid instruction {line}");
                    }
                }
                lines = notReady;
            }
            return circuit[val];
        }
    }
}
