using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public class GameController
    {
        public Location CurrentLocation { get; private set; }

        public string Status
        {
            get
            {
                string status = $"You are in the {CurrentLocation.Name}. You see the following exits:";
                foreach (string str in CurrentLocation.ExitList) status += Environment.NewLine + $" - {str}";
                return status;
            }
        }

        public string Prompt => "Which direction do you want to go: ";

        public GameController()
        {
            CurrentLocation = House.Entry;
        }

        public bool Move(Direction direction)
        {
            var startLocation = CurrentLocation;
            CurrentLocation = CurrentLocation.GetExit(direction);
            return startLocation != CurrentLocation;
        }

        public string ParseInput(string input)
        {
            var result = "That's not a valid direction";
            if (Enum.TryParse(typeof(Direction), input, out object direction))
            {
                if (Move((Direction)direction))
                {
                    result = $"Moving {direction}";
                }
                else result = "There's no exit in that direction";
            }
            return result;
        }
    }
}
