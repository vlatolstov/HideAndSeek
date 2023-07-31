using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public class Location
    {
        public string Name { get; private set; }
        public IDictionary<Direction, Location> Exits { get; private set; } = new Dictionary<Direction, Location>();

        public IEnumerable<string> ExitList => Exits
            .OrderBy(pair => Math.Abs((int)pair.Key))
            .Select(pair => $"the {pair.Value} is {DescribeDirection(pair.Key)}");

        public Location(string name) => Name = name;

        public override string ToString() => Name;

        public void AddExit(Direction direction, Location connectingLocation)
        {
            Exits.Add(direction, connectingLocation);
            connectingLocation.AddReturnExit(direction, this);
        }

        public Location GetExit(Direction direction)
        {
            if (Exits.ContainsKey(direction)) return Exits[direction];
            else return this;
        }
        private void AddReturnExit(Direction direction, Location connectingLocation)
        {
            Exits.Add((Direction)(-(int)direction), connectingLocation);
        }

        private string DescribeDirection(Direction d) => d switch
        {
            Direction.Up => "Up",
            Direction.Down => "Down",
            Direction.In => "In",
            Direction.Out => "Out",
            _ => $"to the {d}"
        };
    }
}
