using Class_Library.Domain;
using Class_Library.Service;
using Class_Library.Interface;
using AM.InfraStructure;
internal class Program
{
    private static void Main(string[] args)
    {
         AMContext context = new AMContext();
        UnitOfWork unitOfWork = new UnitOfWork(context, typeof(GenericRepository<>));
         PlaneMethods planeMethods = new PlaneMethods(unitOfWork);

        // Test avec les données de test existantes
        var testPlane = TestData.BoingPlane;
        var testFlight = TestData.flight1;

        // Test 1: GetPassengersByPlane
        Console.WriteLine("1. Passengers by plane:");
        var passengers = planeMethods.GetPassengersByPlane(testPlane);
        foreach (var p in passengers)
        {
            Console.WriteLine($"- {p.Fullname.FirstName} {p.Fullname.LastName}");
        }

        // Test 2: GetFlightsOrderedByDepartureDate
        Console.WriteLine("\n2. Last 2 planes flights ordered by date:");
        var flights = planeMethods.GetFlightsOrderedByDepartureDate(2);
        foreach (var f in flights)
        {
            Console.WriteLine($"- Flight {f.FlightId}: {f.FlightDate}");
        }

        // Test 3: CanReserveSeats
        Console.WriteLine("\n3. Testing seat reservation:");
        bool canReserve = planeMethods.CanReserveSeats(testFlight, 5);
        Console.WriteLine($"Can reserve 5 seats: {canReserve}");

        // Test 4: GetStaffByFlightId
        Console.WriteLine("\n5. Staff members for flight 1:");
        var staff = planeMethods.GetStaffByFlightId(1);
        foreach (var s in staff)
        {
            Console.WriteLine($"- {s.Fullname.FirstName} {s.Fullname.LastName} ({s.Function})");
        }

        // Test 6: GetTravellersByPlaneAndDate
        Console.WriteLine("\n6. Travellers by plane and date:");
        var travellers = planeMethods.GetTravellersByPlaneAndDate(testPlane, testFlight.FlightDate);
        foreach (var t in travellers)
        {
            Console.WriteLine($"- {t.Fullname.FirstName} {t.Fullname.LastName} ({t.Nationality})");
        }

        // Test 7: GetTravellerCountByDateRange
        Console.WriteLine("\n7. Traveller count by date range:");
        var counts = planeMethods.GetTravellerCountByDateRange(
            DateTime.Now.AddDays(-7), 
            DateTime.Now.AddDays(7)
        );
        foreach (var kvp in counts)
        {
            Console.WriteLine($"- {kvp.Key.ToShortDateString()}: {kvp.Value} travellers");
        }
    }
}