using System;
using System.Collections.Generic;
using Class_Library.Domain;

namespace Class_Library.Interface
{
    public interface IPlaneMethods : IService<Plane>
    {
        // 1. Retourner les voyageurs d’un avion passé en paramètre
        IEnumerable<Passenger> GetPassengersByPlane(Plane plane);

        // 2. Retourner les vols ordonnés par date de départ des n derniers avions
        IEnumerable<Flight> GetFlightsOrderedByDepartureDate(int lastPlanesCount);

        // 3. Retourner true si on peut réserver n places à un vol passé en paramètre
        bool CanReserveSeats(Flight flight, int seatCount);

        // 4. Supprimer tous les avions dont la date de fabrication a dépassé 10 ans
        void RemoveOldPlanes();

        // 5. Retourner la liste des staffs d’un vol dont son identifiant est passé en paramètre
        IEnumerable<Staff> GetStaffByFlightId(int flightId);

        // 6. Retourner la liste des voyageurs qui ont voyagé dans un avion donné à une date donnée
        IEnumerable<Traveller> GetTravellersByPlaneAndDate(Plane plane, DateTime date);

        // 7. Afficher le nombre de voyageurs par date de vol
        Dictionary<DateTime, int> GetTravellerCountByDateRange(DateTime startDate, DateTime endDate);
    }
}
