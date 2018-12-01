using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2016.DayEleven
{
    public class Floors
    {
        int _count = 0;
        int _elevator = 0;
        List<Item>[] _floors = new List<Item>[4];
        static List<Floors> _moves = new List<Floors>();

        public Floors(int elevator = 0)
        {
            _elevator = elevator;
            _floors[0] = new List<Item>();
            _floors[1] = new List<Item>();
            _floors[2] = new List<Item>();
            _floors[3] = new List<Item>();
        }

        public void AddItem(int floor, Item item)
        {
            _floors[floor].Add(item);
        }

        public bool Solved =>
            _elevator == 3 && _floors[0].Count == 0 && _floors[1].Count == 0 && _floors[2].Count == 0;

        public int Solve()
        {
            int min = int.MaxValue;
            IList<Floors> solutions = new List<Floors>();
            foreach(Floors move in ValidMoves())
            {
                if (move.Solved)
                    solutions.Add(move);
                else
                {
                    int localMin = move.Solve();
                    if (localMin < min)
                        min = localMin;
                }
            }
            if (solutions.Count == 0)
                return min;
            return Math.Min(solutions.Min(f => f._count), min);
        }

        public IEnumerable<Floors> ValidMoves()
        {
            var from = _floors[_elevator];
            // Prefer to move up
            if(_elevator != 3)
            {
                var to = _floors[_elevator + 1];
                foreach (var items in ValidMoves(from, to))
                {
                    var move = Move(1, items.Item1, items.Item2);
                    if(!_moves.Contains(move))
                    {
                        _moves.Add(move);
                        yield return move;
                    }
                }
            }

            // Otherwise move down
            if(_elevator != 0)
            {
                var to = _floors[_elevator - 1];
                foreach (var items in ValidMoves(from, to))
                {
                    var move = Move(-1, items.Item1, items.Item2);
                    if (!_moves.Any(m => m.Equals(move)))
                    {
                        _moves.Add(move);
                        yield return move;
                    }
                }
            }
        }

        IEnumerable<(Item, Item?)> ValidMoves(List<Item> from, List<Item> to)
        {
            foreach (Item item in from.Where(i => CanMoveToFloor(i, to)).ToArray())
            {
                // Can move two chips or two generators together
                var sames = from.Where(i => !i.Equals(item) && i.Generator == item.Generator && CanMoveToFloor(i, to));
                foreach (var same in sames)
                    yield return (item, same);

                // Can move a paired chip and generator together
                var matches = from.Where(i => i.Matches(item));
                foreach (var match in matches)
                    yield return (item, match);

                // Can move one item
                yield return (item, null);
            }
        }

        Floors Move(int dir, Item item1, Item? item2)
        {
            Floors move = Clone(dir);
            move._floors[_elevator].Remove(item1);
            move._floors[_elevator + dir].Add(item1);
            if (item2.HasValue)
            {
                move._floors[_elevator].Remove(item2.Value);
                move._floors[_elevator + dir].Add(item2.Value);
            }
            return move;
        }

        Floors Clone(int dir)
        {
            var clone = new Floors();
            clone._count = _count+1;
            clone._elevator = _elevator+dir;
            clone._floors[0].AddRange(_floors[0]);
            clone._floors[1].AddRange(_floors[1]);
            clone._floors[2].AddRange(_floors[2]);
            clone._floors[3].AddRange(_floors[3]);
            return clone;
        }

        bool CanMoveToFloor(Item item, List<Item> floor) =>
            !floor.Any(i => !item.Matches(i) && item.Generator != i.Generator);

        public override bool Equals(object obj)
        {
            var floors = obj as Floors;
            if (floors == null)
                return false;

            if (floors._elevator != _elevator) return false;
            // Do all the counts first because they are less expensive
            for (int i = 0; i < 4; i++)
                if (floors._floors[i].Count != _floors[i].Count) return false;

            for (int i = 0; i < 4; i++)
                if (!floors._floors[i].All(item => _floors[i].Contains(item))) return false;

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for(int i = 3; i >= 0; i--)
            {
                FloorToString(sb, i);
            }
            return sb.ToString();
        }

        void FloorToString(StringBuilder sb, int i)
        {
            sb.Append($"F{i + 1} {(i == _elevator ? 'E' : '.')} ");
            foreach(var item in _floors[i])
            {
                sb.Append(item.ToString());
                sb.Append(" ");
            }
            sb.AppendLine();
        }
    }
}
