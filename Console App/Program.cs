using Class_Library.Domain;

namespace Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Créer un avion
            Plane plane = new Plane
            {
                PlaneId = 1,
                Capacity = 200,
                ManufactureDate = new DateTime(2020, 1, 1),
                PlaneType = PlaneType.Boeing
            };

            // Créer un vol associé à l'avion
            Flight flight = new Flight
            {
                FlightId = 101,
                Departure = "New York",
                Destination = "Paris",
                FlightDate = new DateTime(2023, 10, 15),
                Plane = plane // Associer le vol à l'avion
            };

            // Ajouter le vol à la liste des vols de l'avion
            plane.Flights.Add(flight);

            // Afficher les informations de l'avion et du vol
            Console.WriteLine(plane.ToString());
            Console.WriteLine(flight.ToString());

            // Créer un passager
            Passenger passenger = new Passenger
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "john.doe@example.com"
            };

            // Créer un membre du staff
            Staff staff = new Staff
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                EmailAddress = "jane.smith@example.com",
                Function = "Pilot",
                Salary = 5000,
                EmploymentDate = new DateTime(2018, 5, 10)
            };

            // Créer un voyageur
            Traveller traveller = new Traveller
            {
                Id = 3,
                FirstName = "Alice",
                LastName = "Johnson",
                EmailAddress = "alice.johnson@example.com",
                Nationality = "Canadian",
                HealthInformation = "No allergies"
            };

            // Afficher les informations des passagers
            Console.WriteLine(passenger.ToString());
            Console.WriteLine(staff.ToString());
            Console.WriteLine(traveller.ToString());
        }
    }
}
