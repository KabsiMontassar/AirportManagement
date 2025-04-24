using Class_Library.Domain;
using Class_Library.Interface;

namespace Class_Library.Service
{
    public class FlightMethods : Service<Flight>, IFlightMethods
    {
        public FlightMethods(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Flight> Flights { get; set; } = [];


        public List<DateTime> GetFlightDate(string destination)
        {
            //List<DateTime> date = new List<DateTime>();
            //var query = from f in Flights
            //            where f.Destination == destination
            //            select f.FlightDate;
            //return query.ToList();
            return Flights.Where(f => f.Destination == destination).Select(f => f.FlightDate).ToList();
        }






        public void ShowflightDetails(Plane plane)
        {
            //var query = from flight in Flights
            //            where flight.Plane == plane
            //            select new { flight.Destination, flight.FlightDate };

            var query = Flights.Where(f => f.Plane == plane).Select(f => new { f.Destination, f.FlightDate });

            foreach (var flight in query)
            {
                Console.WriteLine($"Destination: {flight.Destination}, Date: {flight.FlightDate}");
            }



        }



        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //int count = 0;
            //var query = from flight in Flights
            //            where flight.FlightDate >= startDate && flight.FlightDate <= startDate.AddDays(7)
            //            select flight;
            //return query.Count();
            return Flights.Where(f => f.FlightDate >= startDate && f.FlightDate <= startDate.AddDays(7)).Count();

        }

        public double DurationAverage(string destination) //Linq
        {
            //double average = 0;
            //var query = from flight in Flights
            //            where flight.Destination == destination
            //            select flight.EstimatedDuration;
            //if (query.Count() > 0)
            //{
            //    average = query.Average();
            //}
            //return average;

            return Flights.Where(f => f.Destination == destination).Select(f => f.EstimatedDuration).DefaultIfEmpty(0).Average();
            


        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from flight in Flights
            //            orderby flight.EstimatedDuration descending
            //            select flight;

            //return query;

            return Flights.OrderByDescending(f => f.EstimatedDuration);
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)

        {

            //var query = from item in flight.Passengers.OfType<Traveller>()
            //            orderby item.BirthDate descending
            //            select item;

            //return query.Take(3);

            return flight.Passengers.OfType<Traveller>().OrderByDescending(t => t.BirthDate).Take(3);

        }

        public void DestinationGroupedFlights()
        {
            //var query = from flight in Flights
            //            group flight by flight.Destination;

            var query = Flights.GroupBy(f => f.Destination);

            foreach (var flight in query)
            {
                Console.WriteLine($"Destination: {flight}");
                foreach (var f in flight)
                {
                    Console.WriteLine($"Departure: {f.FlightDate}");
                }

            }
        }



        //public List<Flight> GetFlights(string filterType, string filterValue)
        //{
        //    List<Flight> flights = new List<Flight>();
        //    switch (filterType)
        //    {
        //        case "Destination":
        //            foreach (Flight flight in Flights)
        //            {
        //                if (flight.Destination == filterValue)
        //                {
        //                    flights.Add(flight);
        //                }
        //            }
        //            break;
        //        case "Departure":
        //            foreach (Flight flight in Flights)
        //            {
        //                if (flight.Departure == filterValue)
        //                {
        //                    flights.Add(flight);
        //                }
        //            }
        //            break;
        //        case "EffectiveArrival":
        //            foreach (Flight flight in Flights)
        //            {
        //                if (flight.EffectiveArrival == DateTime.Parse(filterValue))
        //                {
        //                    flights.Add(flight);
        //                }
        //            }
        //            break;
        //        case "EstimatedDuration":
        //            foreach (Flight flight in Flights)
        //            {
        //                if (flight.EstimatedDuration == int.Parse(filterValue))
        //                {
        //                    flights.Add(flight);
        //                }
        //            }
        //            break;
        //        case "FlightDate":
        //            foreach (Flight flight in Flights)
        //            {
        //                if (flight.FlightDate == DateTime.Parse(filterValue))
        //                {
        //                    flights.Add(flight);
        //                }
        //            }
        //            break;
        //        default:

        //            break;

        //    }
        //    return flights;

        //}
    }
}
