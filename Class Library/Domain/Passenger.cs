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
        // min max
        [StringLength(25, MinimumLength = 2, ErrorMessage = "FirstName must be between 2 and 25 characters long.")]
        public string FirstName { get; set; }
        //public int Id { get; set; }
        public string LastName { get; set; }
        [Key]
        [StringLength(7, ErrorMessage = "PassportNumber must be 7 characters long.")]
        public string PassportNumber { get; set; }
        [RegularExpression(@"^\d{8}$", ErrorMessage = "TelNumber must be 8 digits long.")]
        public string TelNumber { get; set; }
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
                return FirstName == firstName && LastName == lastName;
            }
            return FirstName == firstName && LastName == lastName && EmailAddress == email;
        }

    


    }
}
