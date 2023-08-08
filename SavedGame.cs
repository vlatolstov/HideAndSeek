using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public class SavedGame
    {
        public string CurrentLocation { get; private set; }
        public Dictionary<string, LocationWithHidingPlace> HiddenOpponents { get; private set; } = new();
        public List<string> FoundOpponents { get; private set; } = new();
        public int MoveNumber { get; private set; }

        public SavedGame(GameController gc)
        {
            CurrentLocation = gc.CurrentLocation.Name;

            foreach (var opp in gc.FoundOpponents)
            {
                FoundOpponents.Add(opp.Name);
            }

            foreach (var loc in House.Locations)
            {
                if (loc.GetType() == typeof(LocationWithHidingPlace))
                {
                    LocationWithHidingPlace hidingLoc = loc as LocationWithHidingPlace;
                    if (hidingLoc.ListOfHiddenOponents.Count > 0)
                    {
                        foreach(var opp in hidingLoc.ListOfHiddenOponents)
                        {
                            HiddenOpponents.Add(opp.Name, hidingLoc);
                        }
                    }
                }
            }

            MoveNumber = gc.MoveNumber;
        }
    }
}
