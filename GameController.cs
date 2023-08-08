using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public class GameController
    {
        public int MoveNumber { get; private set; } = 1;

        public readonly IEnumerable<Opponent> Opponents = new List<Opponent>()
        {
            new Opponent("Joe"),
            new Opponent("Bob"),
            new Opponent("Ana"),
            new Opponent("Owen"),
            new Opponent("Jimmy"),
        };

        public List<Opponent> FoundOpponents { get; private set; } = new();

        public bool GameOver => Opponents.Count() == FoundOpponents.Count();
        public Location CurrentLocation { get; private set; }

        public string Status
        {
            get
            {
                string status = $"You are in the {CurrentLocation.Name}. You see the following exits:";
                foreach (string str in CurrentLocation.ExitList) status += Environment.NewLine + $" - {str}";
                if (CurrentLocation.GetType() == typeof(LocationWithHidingPlace))
                {
                    status += Environment.NewLine + $"Someone could hide {(CurrentLocation as LocationWithHidingPlace).HidingPlace}";
                }
                if (FoundOpponents.Count > 0)
                {
                    status += Environment.NewLine + $"You have found {FoundOpponents.Count} of {Opponents.Count()} opponents: " + String.Join(", ", FoundOpponents);
                }
                return status;
            }
        }

        public string Prompt => $"{MoveNumber}: Which direction do you want to go (or type 'check'): ";

        public GameController()
        {
            House.ClearHidingPlaces();
            foreach (var opp in Opponents)
                opp.Hide();

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
            MoveNumber++;
            input = input[0].ToString().ToUpper() + input.Substring(1).ToLower();
            if (input.ToLower() == "check")
            {
                if (CurrentLocation.GetType() == typeof(LocationWithHidingPlace))
                {
                    var opponentsHere = (CurrentLocation as LocationWithHidingPlace).CheckHidingPlace();
                    string s = "";
                    if (opponentsHere.Count() == 0) return "Nobody was hiding behind the door";
                    if (opponentsHere.Count() > 1) s = "s";
                    Console.Beep();
                    FoundOpponents.AddRange(opponentsHere);
                    return $"You found {opponentsHere.Count()} opponent{s} hiding {(CurrentLocation as LocationWithHidingPlace).HidingPlace}";
                }
                else return $"There is no hiding place in the {CurrentLocation.Name}";
            }
            else
            {
                if (Enum.TryParse(typeof(Direction), input, out object direction))
                {
                    if (Move((Direction)direction))
                    {
                        return $"Moving {direction}";
                    }
                    else
                    {
                        MoveNumber--;
                        return "There's no exit in that direction";
                    }
                }
                else
                {
                    MoveNumber--;
                    return "That's not a valid direction";
                }
            }
        }
    }
}
