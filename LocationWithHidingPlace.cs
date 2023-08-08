using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public class LocationWithHidingPlace : Location
    {
        public string HidingPlace;
        public LocationWithHidingPlace(string name, string hidingPlace) : base(name) => HidingPlace = hidingPlace;

        private List<Opponent> listOfHiddenOponents = new();

        public void Hide(Opponent opponent) => listOfHiddenOponents.Add(opponent);

        public IEnumerable<Opponent> CheckHidingPlace()
        {
            if (listOfHiddenOponents.Any())
            {
                var founded = new List<Opponent>(listOfHiddenOponents);
                listOfHiddenOponents.Clear();
                return founded;
            }
            else return listOfHiddenOponents;
        }

        public void ClearLocation()
        {
            listOfHiddenOponents.Clear();
        }
    }
}
