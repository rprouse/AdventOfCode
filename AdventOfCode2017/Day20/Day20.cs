using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public static class Day20
    {
        public static int PartOne(string filename)
        {
            // Incorrect solution, but it works for the real data, not the test data :(
            Particle.FirstId = 0;
            var particle = GetParticles(filename)
                .OrderBy(p => p.A.Distance)
                .ThenBy(p => p.V.Distance)
                .ThenBy(p => p.P.Distance)
                .First();
            return particle.Id;
        }

        public static int PartTwo(string filename)
        {
            Particle.FirstId = 0;
            var particles = GetParticles(filename).ToList();
            // Number of steps without collisions
            int noCollisions = 0;
            while (noCollisions < 500)
            {
                // Step
                foreach (var p in particles)
                    p.Move();

                // Remove duplicates
                bool collided = false;
                var collisions = particles.GetCollisions();
                while (collisions.Count() > 0)
                {
                    collided = true;
                    particles.RemoveAll(p => collisions.Any(c => c == p.Position));
                    collisions = particles.GetCollisions();
                }
                if (!collided) noCollisions++;
            }
            return particles.Count;
        }

        public static IEnumerable<Particle> GetParticles(string filename) =>
            File.ReadAllLines(filename)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => new Particle(s));

        public static IEnumerable<string> GetCollisions(this IEnumerable<Particle> particles) =>
            particles.GroupBy(p => p.Position).Where(g => g.Count() > 1).Select(g => g.Key);


        public class Particle
        {
            public static int FirstId { get; set; }

            public static Regex regex = new Regex(
                  "p=<(?<px>-?\\d+),(?<py>-?\\d+),(?<pz>-?\\d+)>,\\s*" +
                  "v=<(?<vx>-?\\d+),(?<vy>-?\\d+),(?<vz>-?\\d+)>,\\s*" +
                  "a=<(?<ax>-?\\d+),(?<ay>-?\\d+),(?<az>-?\\d+)>",
                  RegexOptions.CultureInvariant | RegexOptions.Compiled
                );

            public int Id { get; }

            public Point3D P { get; }
            public Point3D V { get; }
            public Point3D A { get; }

            public Particle(string line)
            {
                Match m = regex.Match(line);
                if (!m.Success)
                    throw new ArgumentException(nameof(line));

                Id = FirstId++;
                P = new Point3D(m.GetLong("px"), m.GetLong("py"), m.GetLong("pz"));
                V = new Point3D(m.GetLong("vx"), m.GetLong("vy"), m.GetLong("vz"));
                A = new Point3D(m.GetLong("ax"), m.GetLong("ay"), m.GetLong("az"));
            }

            // Moves and returns the distance from center
            public long Move()
            {
                V.X += A.X;
                V.Y += A.Y;
                V.Z += A.Z;
                P.X += V.X;
                P.Y += V.Y;
                P.Z += V.Z;
                return P.Distance;
            }

            public string Position => P.ToString();
        }

        public class Point3D
        {
            public Point3D(long x, long y, long z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public long X { get; set; }
            public long Y { get; set; }
            public long Z { get; set; }

            public long Distance => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);

            public override string ToString() => $"{X},{Y},{Z}";
        }
    }
}
