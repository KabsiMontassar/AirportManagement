using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library.Domain
{
    public class Flight
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }

        public Plane Plane { get; set; }
        public override string ToString()
        {
            return $"Flight ID: {FlightId}, Departure: {Departure}, Destination: {Destination}, Date: {FlightDate.ToShortDateString()}";
        }
    }
}
