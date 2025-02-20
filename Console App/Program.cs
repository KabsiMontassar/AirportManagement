using Class_Library.Domain;
using Class_Library.Service;


  
        FlightMethods flightmethods = new()
        {
            Flights = TestData.listFlights
        };


flightmethods.DestinationGroupedFlights();
    