using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightentity
{
    public class flight
    {
        public string flightId { get; set; }
        public string origin { get; set; }
        public string Destination { get; set; }
        public string DateOfTravel { get; set; }
        public string TravelTime { get; set; }
        public string Distance { get; set; }
        public int price { get; set; }
        public int AvailbleSeats { get; set; }
    }
}
