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
        static House()
        {
            Entry = new Location("Entry");
            Location garage = new("Garage");
            Location hallway = new("Hallway");
            Entry.AddExit(Direction.Out, garage);
            Entry.AddExit(Direction.East, hallway);

            Location bathroom = new("Bathroom");
            Location kitchen = new("Kitchen");
            Location livingroom = new("Living Room");
            Location landing = new("Landing");
            hallway.AddExit(Direction.North, bathroom);
            hallway.AddExit(Direction.Northwest, kitchen);
            hallway.AddExit(Direction.South, livingroom);
            hallway.AddExit(Direction.Up, landing);

            Location masterBedroom = new("Master Bedroom");
            Location secondBathroom = new("Second Bathroom");
            Location nursery = new("Nursery");
            Location kidsRoom = new("Kids Room");
            Location pantry = new("Pantry");
            Location attic = new("Attic");
            landing.AddExit(Direction.Northwest, masterBedroom);
            landing.AddExit(Direction.West, secondBathroom);
            landing.AddExit(Direction.Southwest, nursery);
            landing.AddExit(Direction.South, pantry);
            landing.AddExit(Direction.Southeast, kidsRoom);
            landing.AddExit(Direction.Up, attic);

            Location masterBath = new("Master Bath");
            masterBedroom.AddExit(Direction.East, masterBath);
        }
    }
}
