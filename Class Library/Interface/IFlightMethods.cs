using Class_Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library.Interface
{
    public interface IFlightMethods
    {
        List<DateTime> GetFlightDate(string destination);

        void ShowflightDetails(Plane plane);

        int ProgrammedFlightNumber(DateTime startDate);

        double DurationAverage(string destination);
        IEnumerable<Flight> OrderedDurationFlights();

        IEnumerable<Traveller> SeniorTravellers(Flight flight);
        void DestinationGroupedFlights();

    }
}
