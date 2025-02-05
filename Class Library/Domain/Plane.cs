namespace Class_Library.Domain
{
    public class Plane
    {
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }

        public ICollection<Flight> Flights { get; set; } = [];
        public override string ToString()
        {
            return $"Plane ID: {PlaneId}, Type: {PlaneType}, Capacity: {Capacity}, Manufacture Date: {ManufactureDate.ToShortDateString()}";
        }
    }
}
