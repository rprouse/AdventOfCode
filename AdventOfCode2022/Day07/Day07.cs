using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day07
{
    public static int PartOne(string filename)
    {
        Directory root = PlaybackCommands(filename);
        return 0;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }

    private static Directory PlaybackCommands(string filename)
    {
        string[] commands = filename.ReadAllLines();
        var root = new Directory("/", null);
        var pwd = root;
        foreach (string cmd in commands.Skip(1))
        {
            if (cmd[0] == '$') // Command
            {
                if (cmd == "$ ls") continue;
                if (cmd == "$ cd ..")
                {
                    if (pwd.ParentDirectory == null)
                        throw new NotSupportedException("No parent directory");

                    pwd = pwd.ParentDirectory;
                    continue;
                }
                var name = cmd.Substring(5);
                var dir = pwd.Directories.FirstOrDefault(d => d.Name == name);
                if (dir == null)
                {
                    dir = new Directory(name, pwd);
                    pwd.Directories.Add(dir);
                }
                pwd = dir;
            }
            else // Output
            {
                if (cmd.StartsWith("dir"))
                {
                    var name = cmd.Substring(4);
                    var dir = pwd.Directories.FirstOrDefault(d => d.Name == name);
                    if (dir == null)
                    {
                        dir = new Directory(name, pwd);
                        pwd.Directories.Add(dir);
                    }
                }
                else
                {
                    var parts = cmd.Split(' ');
                    var file = new File(parts[1], parts[0].ToInt());
                    pwd.Files.Add(file);
                }
            }
        }
        return root;
    }
}

internal class Directory
{
    public Directory(string name, Directory parent)
    {
        Name = name;
        ParentDirectory = parent;
    }

    public string Name { get; set; }
    public Directory ParentDirectory { get; set; }
    public IList<Directory> Directories { get; } = new List<Directory>();
    public IList<File> Files { get; } = new List<File>();

    public long Size() =>
        Files.Sum(f => f.Size) + Directories.Sum(d => d.Size());

    public IEnumerable<long> SizeOfDirectoriesLargerThan(long size)
    {
        yield return 0;
    }
}

internal record File(string Name, long Size);
