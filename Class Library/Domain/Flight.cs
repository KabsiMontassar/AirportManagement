using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Class_Library.Domain
{
    public class Flight
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        [Key]
        public int FlightId { get; set; }

        public string AirlineLogo { get; set; }

        public ICollection<Passenger> Passengers { get; set; }


        [ForeignKey("Plane")]
        public int Planefk { get; set; } 
        public Plane Plane { get; set; }

        public override string ToString()
        {
            return $"Flight ID: {FlightId}, Departure: {Departure}, Destination: {Destination}, Date: {FlightDate.ToShortDateString()}";
        }
    }
}
