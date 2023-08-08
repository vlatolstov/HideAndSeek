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

        public List<Opponent> ListOfHiddenOponents { get; private set; } = new();

        public void Hide(Opponent opponent) => ListOfHiddenOponents.Add(opponent);

        public IEnumerable<Opponent> CheckHidingPlace()
        {
            if (ListOfHiddenOponents.Any())
            {
                var founded = new List<Opponent>(ListOfHiddenOponents);
                ListOfHiddenOponents.Clear();
                return founded;
            }
            else return ListOfHiddenOponents;
        }

        public void ClearLocation()
        {
            ListOfHiddenOponents.Clear();
        }
    }
}
