using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public static class House
    {
        public static Location Entry { get; private set; }
        public static IEnumerable<Location> Locations { get; private set; }
        public static Random Random = new();

        static House()
        {
            var locationsList = new List<Location>();

            Entry = new Location("Entry");
            LocationWithHidingPlace garage = new("Garage", "under the car");
            Location hallway = new("Hallway");
            Entry.AddExit(Direction.Out, garage);
            Entry.AddExit(Direction.East, hallway);
            locationsList.Add(Entry);
            locationsList.Add(garage);
            locationsList.Add(hallway);

            LocationWithHidingPlace bathroom = new("Bathroom", "behind the door");
            LocationWithHidingPlace kitchen = new("Kitchen", "under the table");
            LocationWithHidingPlace livingroom = new("Living Room", "behind the TV");
            Location landing = new("Landing");
            hallway.AddExit(Direction.North, bathroom);
            hallway.AddExit(Direction.Northwest, kitchen);
            hallway.AddExit(Direction.South, livingroom);
            hallway.AddExit(Direction.Up, landing);
            locationsList.Add(bathroom);
            locationsList.Add(kitchen);
            locationsList.Add(livingroom);
            locationsList.Add(landing);

            LocationWithHidingPlace masterBedroom = new("Master Bedroom", "under the bed");
            LocationWithHidingPlace secondBathroom = new("Second Bathroom", "in the bath");
            LocationWithHidingPlace nursery = new("Nursery", "under the table");
            LocationWithHidingPlace kidsRoom = new("Kids Room", "in the wardrobe");
            LocationWithHidingPlace pantry = new("Pantry", "in the dusty bag");
            LocationWithHidingPlace attic = new("Attic", "in the wooden chest");
            landing.AddExit(Direction.Northwest, masterBedroom);
            landing.AddExit(Direction.West, secondBathroom);
            landing.AddExit(Direction.Southwest, nursery);
            landing.AddExit(Direction.South, pantry);
            landing.AddExit(Direction.Southeast, kidsRoom);
            landing.AddExit(Direction.Up, attic);
            locationsList.Add(masterBedroom);
            locationsList.Add(secondBathroom);
            locationsList.Add(nursery);
            locationsList.Add(kidsRoom);
            locationsList.Add(pantry);
            locationsList.Add(attic);

            LocationWithHidingPlace masterBath = new("Master Bath", "in the bath");
            masterBedroom.AddExit(Direction.East, masterBath);
            locationsList.Add(masterBath);

            Locations = locationsList;
        }

        public static Location GetLocationByName(string name)
        {
            var namedLocation = Locations.Where(loc => loc.Name == name);
            if (!namedLocation.Any()) return Entry;
            else return namedLocation.First();
        }

        public static Location RandomExit(Location location) => location.Exits
            .OrderBy(loc => loc.Value.Name)
            .ElementAt(Random.Next(location.Exits.Count))
            .Value;

        public static void ClearHidingPlaces()
        {
            var hidenPlaces = Locations.Where(loc => loc.GetType() == typeof(LocationWithHidingPlace));
            foreach (LocationWithHidingPlace loc in hidenPlaces) loc.ClearLocation();
        }
    }
}
