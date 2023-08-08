using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HideAndSeek
{
    public class Opponent
    {
        public readonly string Name;
        public Opponent(string name) => Name = name;

        public override string ToString() => Name;

        public void Hide()
        {
            Location currentLoc = House.Entry;
            for (int i = 0; i < House.Random.Next(10, 51); i++)
            {
                currentLoc = House.RandomExit(currentLoc);
            }
            while (currentLoc.GetType() != typeof(LocationWithHidingPlace)) currentLoc = House.RandomExit(currentLoc);
            (currentLoc as LocationWithHidingPlace).Hide(this);
            System.Diagnostics.Debug.WriteLine($"{Name} is hiding " + $"{(currentLoc as LocationWithHidingPlace).HidingPlace} in the {currentLoc.Name}");
        }
    }
}