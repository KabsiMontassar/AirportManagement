using System;
using System.Collections.Generic;
using System.Linq;
using Class_Library.Domain;
using Class_Library.Interface;
using Class_Library.Service;

namespace Class_Library.Service
{
    public class PlaneMethods : Service<Plane>, IPlaneMethods
    {
        public PlaneMethods(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // 1. Retourner les voyageurs d’un avion passé en paramètre
        public IEnumerable<Passenger> GetPassengersByPlane(Plane plane)
        {
            return plane.Flights?.SelectMany(f => f.Passengers);
        }

        // 2. Retourner les vols ordonnés par date de départ des n derniers avions
        public IEnumerable<Flight> GetFlightsOrderedByDepartureDate(int lastPlanesCount)
        {
            var recentPlanes = GetAll().OrderByDescending(p => p.ManufactureDate)
                                       .Take(lastPlanesCount);
            return recentPlanes.SelectMany(p => p.Flights)
                               .OrderBy(f => f.FlightDate);
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
            var oldPlanes = GetAll().Where(p => p.ManufactureDate < thresholdDate);
            foreach (var plane in oldPlanes)
            {
                Delete(plane);
            }
            Commit();
        }

        // 5. Retourner la liste des staffs d’un vol dont son identifiant est passé en paramètre
        public IEnumerable<Staff> GetStaffByFlightId(int flightId)
        {
            var flight = GetAll().SelectMany(p => p.Flights)
                                 .FirstOrDefault(f => f.FlightId == flightId);
            return flight?.Passengers.OfType<Staff>();
        }

        // 6. Retourner la liste des voyageurs qui ont voyagé dans un avion donné à une date donnée
        public IEnumerable<Traveller> GetTravellersByPlaneAndDate(Plane plane, DateTime date)
        {
            return plane.Flights?.Where(f => f.FlightDate.Date == date.Date)
                                 .SelectMany(f => f.Passengers.OfType<Traveller>());
                                 
        }

        // 7. Afficher le nombre de voyageurs par date de vol
        public Dictionary<DateTime, int> GetTravellerCountByDateRange(DateTime startDate, DateTime endDate)
        {
            return GetAll().SelectMany(p => p.Flights)
                           .Where(f => f.FlightDate >= startDate && f.FlightDate <= endDate)
                           .GroupBy(f => f.FlightDate.Date)
                           .ToDictionary(g => g.Key, g => g.SelectMany(f => f.Passengers).Count());
        }
    }
}