using Class_Library.Domain;
using Class_Library.Interface;

namespace Class_Library.Service
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = [];

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



        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> flights = new List<Flight>();
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                        {
                            flights.Add(flight);
                        }
                    }
                    break;
                case "Departure":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Departure == filterValue)
                        {
                            flights.Add(flight);
                        }
                    }
                    break;
                case "EffectiveArrival":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.EffectiveArrival == DateTime.Parse(filterValue))
                        {
                            flights.Add(flight);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.EstimatedDuration == int.Parse(filterValue))
                        {
                            flights.Add(flight);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.FlightDate == DateTime.Parse(filterValue))
                        {
                            flights.Add(flight);
                        }
                    }
                    break;
                default:

                    break;

            }
            return flights;

        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
