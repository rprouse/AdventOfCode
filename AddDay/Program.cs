using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace AddDay
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = "2020";
            if (args.Length == 1)
                year = args[0];

            string dir = ProjectDirectory(year);
            if (!Directory.Exists(dir))
            {
                Console.WriteLine($"{dir} does not exist.");
                return;
            }

            var days = Directory.GetDirectories(dir, "Day*")
                                .Select(s => int.TryParse(s.Substring(s.Length - 2), out int day) ? day : 0)
                                .OrderByDescending(i => i);
            int newDay = days.First() + 1;

            string newDir = Path.Combine(dir, $"Day{newDay:00}");
            string newSource = Path.Combine(newDir, $"Day{newDay:00}.cs");
            string newTest = Path.Combine(newDir, $"Day{newDay:00}Tests.cs");
            Directory.CreateDirectory(newDir);
            File.Copy(Path.Combine(dir, "Day00", "Data.txt"), Path.Combine(newDir, "Data.txt"));
            File.Copy(Path.Combine(dir, "Day00", "Test.txt"), Path.Combine(newDir, "Test.txt"));
            File.Copy(Path.Combine(dir, "Day00", "Day00.cs"), newSource);
            File.Copy(Path.Combine(dir, "Day00", "Day00Tests.cs"), newTest);

            UpdateDayInFile(newSource, newDay);
            UpdateDayInFile(newTest, newDay);

            UpdateProjectFile(dir, year, newDay);

            Console.WriteLine($"Added Day{newDay:00}");
        }

        static string ProjectDirectory(string year) =>
            $@"C:\Src\Alteridem\AdventOfCode\AdventOfCode{year}";

        static void UpdateDayInFile(string filename, int day)
        {
            string contents = File.ReadAllText(filename);
            contents = contents.Replace("00", $"{day:00}");
            File.WriteAllText(filename, contents);
        }

        static void UpdateProjectFile(string dir, string year, int day)
        {
            string file = Path.Combine(dir, $"AdventOfCode{year}.csproj");

            XDocument proj = XDocument.Load(file);
            XElement itemGroup = proj.Descendants("ItemGroup").Last();

            XElement data = new XElement("None", 
                new XAttribute("Update", $@"Day{day:00}\Data.txt"),
                new XElement("CopyToOutputDirectory", "PreserveNewest"));
            itemGroup.Add(data);

            XElement test = new XElement("None",
                new XAttribute("Update", $@"Day{day:00}\Test.txt"),
                new XElement("CopyToOutputDirectory", "PreserveNewest"));
            itemGroup.Add(test);

            proj.Save(file);
        }
    }
}
