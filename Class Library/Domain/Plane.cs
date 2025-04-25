using System.ComponentModel.DataAnnotations;

namespace Class_Library.Domain
{
    public class Plane
    {
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be a positive number.")]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        [Key]
        public int PlaneId { get; set; }
        virtual public PlaneType PlaneType { get; set; }

        public ICollection<Flight> Flights { get; set; } = [];
        public override string ToString()
        {
            return $"Plane ID: {PlaneId}, Type: {PlaneType}, Capacity: {Capacity}, Manufacture Date: {ManufactureDate.ToShortDateString()}";
        }
    }
}
