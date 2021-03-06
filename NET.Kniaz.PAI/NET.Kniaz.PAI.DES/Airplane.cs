using System;


namespace NET.Kniaz.PAI.DES.Objects
{
    class Airplane
    {
        public Guid Id { get; set; }
        public int PassengersCount { get; set; }
        public double TimeToTakeOff { get; set; }
        public int RunwayOccupied { get; set; }
        public bool BrokenDown { get; set; }

        public Airplane(int passengers)
        {
            Id = Guid.NewGuid();
            PassengersCount = passengers;
            RunwayOccupied = -1;
        }
    }
}
