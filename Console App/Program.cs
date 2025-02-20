using Class_Library.Domain;
using Class_Library.Service;


internal class Program
{
    private static void Main(string[] args)
    {
        Passenger p = new Passenger
        {
            FirstName = "montassar",
            LastName = "kebsi"
        };

        p.UpperFullName();

        Console.WriteLine(p.FirstName);
        Console.WriteLine(p.LastName);
        
    }
}