namespace Class_Library.Domain
{
    public class Passenger
    {

        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public int TelNumber { get; set; }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

        public bool CheckProfile(string firstName, string lastName)
        {
            return FirstName == firstName && LastName == lastName;
        }

        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return FirstName == firstName && LastName == lastName && EmailAddress == email;
        }

        //public bool CheckProfile(string firstName, string lastName, string email = null)
        //{
        //    if (string.IsNullOrEmpty(email))  // If email is not provided, check only the name
        //    {
        //        return FirstName == firstName && LastName == lastName;
        //    }
        //    // If email is provided, check all attributes (name + email)
        //    return FirstName == firstName && LastName == lastName && EmailAddress == email;
        //}

        public override string ToString()
        {
            return $"Passenger ID: {Id}, Name: {FirstName} {LastName}, Email: {EmailAddress}";
        }


    }
}
