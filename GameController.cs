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
                string status = $"You are in the {CurrentLocation.Name}. Ypu see the following exits: ";
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
            return !(CurrentLocation.GetExit(direction) == CurrentLocation);
        }

        public string ParseInput(string input)
        {
            throw new NotImplementedException();
        }
    }
}
