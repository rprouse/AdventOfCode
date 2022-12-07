using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day07
{
    public static long PartOne(string filename)
    {
        Directory root = PlaybackCommands(filename);
        return root.DirectoriesSmallerThan(100000).Sum(d => d.Size());
    }

    public static long PartTwo(string filename)
    {
        Directory root = PlaybackCommands(filename);
        var free = 70000000 - root.Size();
        var needed = 30000000 - free;
        var possible = root.DirectoriesLargerThan(needed);
        return possible.Min(d => d.Size());
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

    long _cachedSize = -1;
    public long Size()
    {
        if (_cachedSize < 0)
            _cachedSize = Files.Sum(f => f.Size) + Directories.Sum(d => d.Size());

        return _cachedSize;
    }

    public IEnumerable<Directory> DirectoriesSmallerThan(long size)
    {
        foreach (var dir in Directories)
        {
            if (dir.Size() <= size) yield return dir;
            foreach (var subdir in dir.DirectoriesSmallerThan(size))
            {
                yield return subdir;
            }
        }
    }

    public IEnumerable<Directory> DirectoriesLargerThan(long size)
    {
        foreach (var dir in Directories)
        {
            if (dir.Size() >= size) yield return dir;
            foreach (var subdir in dir.DirectoriesLargerThan(size))
            {
                yield return subdir;
            }
        }
    }

    public override string ToString() => $"{Name}: {Size()}";
}

internal record File(string Name, long Size);
