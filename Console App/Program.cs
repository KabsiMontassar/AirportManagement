using Class_Library.Domain;
using Class_Library.Service;

FlightMethods flightmethods = new();



flightmethods.Flights = TestData.listFlights;

foreach (var flight in flightmethods.GetFlights("Destination", "Madrid"))
{
    Console.WriteLine(flight);
}
