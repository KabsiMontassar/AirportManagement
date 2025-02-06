using Class_Library.Domain;
using Class_Library.Service;

FlightMethods flightmethods = new();



flightmethods.Flights = TestData.listFlights;

foreach( var flight in flightmethods.GetFlightDate("Paris"))
{
    Console.WriteLine(flight);
}
