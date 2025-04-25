using System.ComponentModel.DataAnnotations;

namespace Class_Library.Domain
{
    public class Passenger
    {




        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]

        public DateTime BirthDate { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }


        virtual public ICollection<ReservationTicket> ReservationsTickets { get; set; }



        public Fullname Fullname { get; set; }

        [Key]
        [StringLength(7, ErrorMessage = "PassportNumber must be 7 characters long.")]
        public string PassportNumber { get; set; }
        [RegularExpression(@"^\d{8}$", ErrorMessage = "TelNumber must be 8 digits long.")]
        public string TelNumber { get; set; }

        virtual public List<Flight> Flights { get; set; } 
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

        //public bool CheckProfile(string firstName, string lastName)
        //{
        //    return FirstName == firstName && LastName == lastName;
        //}

        //public bool CheckProfile(string firstName, string lastName, string email)
        //{
        //    return FirstName == firstName && LastName == lastName && EmailAddress == email;
        //}

        public bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (string.IsNullOrEmpty(email)) 
            {
                return Fullname.FirstName == firstName && Fullname.LastName == lastName;
            }
            return Fullname.FirstName == firstName && Fullname.LastName == lastName && EmailAddress == email;
        }

    


    }
}
