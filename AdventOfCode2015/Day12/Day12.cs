using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day12
    {
        public static int PartOne(string filename) =>
            SumNumbers(filename.ReadAll());

        internal static int SumNumbers(string json) =>
            SumJsonNode(JsonNode.Parse(json));

        private static int SumJsonNode(JsonNode node)
        {
            int sum = 0;
            JsonValue val = node as JsonValue;
            if (val != null && val.TryGetValue<int>(out int n))
            {
                sum += n;
            }
            JsonObject obj = node as JsonObject;
            if (obj != null)
            {
                foreach (var item in obj)
                {
                    sum += SumJsonNode(item.Value);
                }
            }
            JsonArray array = node as JsonArray;
            if(array != null)
            {
                sum += array.Sum(n => SumJsonNode(n));
            }
            return sum;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
