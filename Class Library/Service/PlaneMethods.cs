using System;
using System.Collections.Generic;
using System.Linq;
using Class_Library.Domain;
using Class_Library.Interface;

namespace Class_Library.Service
{
    public class PlaneMethods : Service<Plane>, IPlaneMethods
    {
        private readonly List<Plane> Planes;
        private readonly List<Flight> Flights;

        public PlaneMethods(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Planes = unitOfWork.Repository<Plane>().GetAll().ToList();
            Flights = unitOfWork.Repository<Flight>().GetAll().ToList();
        }

        // 1. Retourner les voyageurs d’un avion passé en paramètre
        public List<Passenger> GetPassengersByPlane(Plane plane)
        {
            return Flights.Where(f => f.Plane == plane)
                          .SelectMany(f => f.Passengers)
                          .ToList();
        }

        // 2. Retourner les vols ordonnés par date de départ des n derniers avions
        public List<Flight> GetFlightsOrderedByDepartureDate(int lastPlanesCount)
        {
            var recentPlanes = Planes.OrderByDescending(p => p.ManufactureDate)
                                     .Take(lastPlanesCount);
            return Flights.Where(f => recentPlanes.Contains(f.Plane))
                          .OrderBy(f => f.FlightDate)
                          .ToList();
        }

        // 3. Retourner true si on peut réserver n places à un vol passé en paramètre
        public bool CanReserveSeats(Flight flight, int seatCount)
        {
            return flight.Plane.Capacity - flight.Passengers.Count >= seatCount;
        }

        // 4. Supprimer tous les avions dont la date de fabrication a dépassé 10 ans
        public void RemoveOldPlanes()
        {
            var thresholdDate = DateTime.Now.AddYears(-10);
            var oldPlanes = Planes.Where(p => p.ManufactureDate < thresholdDate).ToList();
            foreach (var plane in oldPlanes)
            {
                Delete(plane);
            }
            Commit();
        }

        // 5. Retourner la liste des staffs d’un vol dont son identifiant est passé en paramètre
        public List<Staff> GetStaffByFlightId(int flightId)
        {
            return Flights.Where(f => f.FlightId == flightId)
                          .SelectMany(f => f.Passengers.OfType<Staff>())
                          .ToList();
        }

        // 6. Retourner la liste des voyageurs qui ont voyagé dans un avion donné à une date donnée
        public List<Traveller> GetTravellersByPlaneAndDate(Plane plane, DateTime date)
        {
            return Flights.Where(f => f.Plane == plane && f.FlightDate.Date == date.Date)
                          .SelectMany(f => f.Passengers.OfType<Traveller>())
                          .ToList();
        }

        // 7. Afficher le nombre de voyageurs par date de vol
        public Dictionary<DateTime, int> GetTravellerCountByDateRange(DateTime startDate, DateTime endDate)
        {
            return Flights.Where(f => f.FlightDate >= startDate && f.FlightDate <= endDate)
                          .GroupBy(f => f.FlightDate.Date)
                          .ToDictionary(g => g.Key, g => g.SelectMany(f => f.Passengers).Count());
        }
    }
}