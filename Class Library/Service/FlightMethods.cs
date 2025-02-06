using Class_Library.Domain;
using Class_Library.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library.Service 
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; }  = [];

        public List<DateTime> GetFlightDate(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();
            foreach (Flight flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    flightDates.Add(flight.FlightDate);
                }
            }
            return flightDates;

        }
    }
}
